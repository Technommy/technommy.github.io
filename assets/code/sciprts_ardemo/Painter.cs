using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Unity.Engine.UI
{
	[AddComponentMenu("UI/Painter", 10)] // Add to UI Component options
	public class Painter : MonoBehaviour {

		public Texture2D sourceBaseTex;
		private Texture2D baseTex;

		int width; // width of the object to capture
		int height; // height of the object to capture

		string Url;
		string lUrl;
		public string lUrlFirst = "http://172.24.1.107/?LED=";
		public string lUrlAlphabet;
		public string lUrlEnd = "&submit=Send";

		/*
		 * screenPos.x - ((baseTex.width * zoom) / 2),
		 * Screen.height - screenPos.y - ((baseTex.height * zoom) / 2),
		 * baseTex.width * zoom,
		 * baseTex.height * zoom
		 */

		// [SerializeField]

		void Start()
		{
			baseTex = (Texture2D)Instantiate(sourceBaseTex);
			width = System.Convert.ToInt32((baseTex.width * zoom) - ((baseTex.width * zoom) / 4)); 
			height = System.Convert.ToInt32((baseTex.height * zoom) - ((baseTex.height * zoom) / 4));
			// StartCoroutine(UploadPNG());
		}

		void PostDataFlask()
		{
			string JsonArraystring = "{\"image_url\":\"http://172.24.1.111:8000/AssetsScreenShot_partial.jpg\"}";
			// Hashtable headers = new Hashtable();
			Dictionary<string, string> headers = new Dictionary<string, string>();
			headers.Add("Content-Type", "application/json");
			byte[] body = Encoding.UTF8.GetBytes(JsonArraystring);
			WWW www = new WWW(Url, body, headers);
			StartCoroutine("PostdataEnumerator", www);
			StartCoroutine(PostdataLEDEnumerator());
		}

		public void RestartGame()
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
		}
			
		public IEnumerator takeScreenShot()
		{
			Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);

			yield return new WaitForEndOfFrame ();

			var startX = screenPos.x - ((baseTex.width * zoom) / 2);
			var startY = Screen.height - screenPos.y - ((baseTex.height * zoom) / 2);

			var tex = new Texture2D (width, height, TextureFormat.RGB24, false);
			tex.ReadPixels (new Rect(startX, startY, width, height), 0, 0);
			tex.Apply ();

			var bytes = tex.EncodeToJPG();
			Destroy(tex);

			File.WriteAllBytes(Application.dataPath + "ScreenShot_partial.jpg", bytes);

			Url = "http://172.24.1.111:5000/v1/ocr";
			PostDataFlask();
		}

		IEnumerator PostdataEnumerator(WWW www)
		{
			yield return www;
			Debug.Log(www.text);
			lUrlAlphabet = www.text;
			lUrl = lUrlFirst + lUrlAlphabet + lUrlEnd;
			// Debug.Log(lUrl);
		}

		IEnumerator PostdataLEDEnumerator() {
			WWW www = new WWW(lUrl);
			yield return www;
			// Renderer renderer = GetComponent<Renderer>();
			// renderer.material.mainTexture = www.texture;
			Debug.Log(lUrl);
		}

		private Vector2 dragStart;
		private Vector2 dragEnd;
		public enum Tool
		{
			None,
			Line,
			Brush,
			Eraser,
			Vector
		}
		private int tool2 = 1;
		public Drawing.Samples AntiAlias;
		public Tool tool = Tool.Brush;
		public Texture[] toolimgs;
		public Texture2D colorCircle;
		public float lineWidth = 1;
		public float strokeWidth = 1;
		public Color col = Color.white;
		public Color col2 = Color.white;
		public GUISkin gskin;
		public LineTool lineTool = new LineTool();   // http://catlikecoding.com/unity/tutorials/curves-and-splines/
		public BrushTool brush = new BrushTool();
		public EraserTool eraser = new EraserTool();
		public Stroke stroke = new Stroke();
		public float zoom = 1;

		Drawing.BezierPoint[] BezierPoints;

		void OnGUI()
		{
			Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);

			GUI.skin = gskin;

			/* ===== Buttons ===== */

			if(GUI.Button(new Rect(0,0, 200, 100), "Capture"))
			{
				StartCoroutine (takeScreenShot ());
			}

			if(GUI.Button(new Rect(0,110, 200, 100), "Reset"))
			{
				RestartGame ();
			}

			/* ===== Buttons ===== */

			GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height), "", "Box");
			GUILayout.BeginArea(new Rect(0, 0, 0, Screen.height));
			tool2 = GUILayout.Toolbar(tool2, toolimgs, "Tool");

			tool = Tool.Brush;

			// GUILayout.Label("");
			GUILayout.Space(0);
			switch (tool)
			{
			case Tool.Line:
				GUILayout.Label("Size " + Mathf.Round(lineTool.width * 10) / 10);
				lineTool.width = GUILayout.HorizontalSlider(lineTool.width, 0, 40);
				col = GUIControls.RGBCircle(col, "", colorCircle);
				break;
			case Tool.Brush:
				GUILayout.Label("S" + Mathf.Round(brush.width * 10) / 10);
				brush.width = GUILayout.HorizontalSlider(brush.width, 0, 40);
				GUILayout.Label("H" + Mathf.Round(brush.hardness * 10) / 10);
				brush.hardness = GUILayout.HorizontalSlider(brush.hardness, 0.1f, 50);
				col = GUIControls.RGBCircle(col, "", colorCircle);
				break;
			case Tool.Eraser:
				GUILayout.Label("Size " + Mathf.Round(eraser.width * 10) / 10);
				eraser.width = GUILayout.HorizontalSlider(eraser.width, 0, 50);
				GUILayout.Label("Hardness " + Mathf.Round(eraser.hardness * 10) / 10);
				eraser.hardness = GUILayout.HorizontalSlider(eraser.hardness, 1, 50);
				break;
			}

			if (tool == Tool.Line)
			{
				stroke.enabled = GUILayout.Toggle(stroke.enabled, "Stroke");
				GUILayout.Label("Stroke Width " + Mathf.Round(stroke.width * 10) / 10);
				stroke.width = GUILayout.HorizontalSlider(stroke.width, 0, lineWidth);
				GUILayout.Label("Secondary Color");
				col2 = GUIControls.RGBCircle(col2, "", colorCircle);
			}

			GUILayout.EndArea();
			// GUI.DrawTexture(new Rect(screenPos.x - 50, ((Screen.height - screenPos.y) / 2 - 50), baseTex.width * zoom, baseTex.height * zoom), baseTex);
			GUI.DrawTexture(new Rect(screenPos.x - ((baseTex.width * zoom) / 2), Screen.height - screenPos.y - ((baseTex.height * zoom) / 2), baseTex.width * zoom, baseTex.height * zoom), baseTex);
			// GUI.DrawTexture(new Rect(screenPos.x, Screen.height - screenPos.y, 250, 250), baseTex);
			// GUI.DrawTexture(new Rect(0, 0, baseTex.width * zoom, baseTex.height * zoom), baseTex);
			GUILayout.EndArea();
		}

		private Vector2 preDrag;

		void Update()
		{
			Vector3 screenPos= Camera.main.WorldToScreenPoint(this.transform.position);

			// Rect imgRect = new Rect (screenPos.x, Screen.height - screenPos.y, 250, 250);
			// Rect imgRect = new Rect (screenPos.x - ((baseTex.width * zoom) / 2), Screen.height - screenPos.y - ((baseTex.height * zoom) / 2), Screen.width, Screen.height);
			Rect imgRect = new Rect (screenPos.x - ((baseTex.width * zoom) / 2), Screen.height - screenPos.y - ((baseTex.height * zoom) / 2), baseTex.width * zoom, baseTex.height * zoom);
			// Rect imgRect = new Rect(0, 0, baseTex.width * zoom, baseTex.height * zoom);
			Vector2 mouse = Input.mousePosition;
			mouse.y = Screen.height - mouse.y;

			if (Input.GetKeyDown("t"))
			{
				test();
			}
			if (Input.GetKeyDown("mouse 0"))
			{

				if (imgRect.Contains(mouse))
				{
					if (tool == Tool.Vector)
					{
						var m2 = mouse - new Vector2(imgRect.x, imgRect.y);
						m2.y = imgRect.height - m2.y;
						var bz = new ArrayList(BezierPoints);
						bz.Add(new Drawing.BezierPoint(m2, m2 - new Vector2(50, 10), m2 + new Vector2(50, 10)));
						BezierPoints = (Drawing.BezierPoint[])bz.ToArray();
						Drawing.DrawBezier(BezierPoints, lineTool.width, col, baseTex);
					}

					dragStart = mouse - new Vector2(imgRect.x, imgRect.y);
					dragStart.y = imgRect.height - dragStart.y;
					dragStart.x = Mathf.Round(dragStart.x / zoom);
					dragStart.y = Mathf.Round(dragStart.y / zoom);
					// LineStart (mouse - Vector2 (imgRect.x,imgRect.y));

					dragEnd = mouse - new Vector2(imgRect.x, imgRect.y);
					dragEnd.x = Mathf.Clamp(dragEnd.x, 0, imgRect.width);
					dragEnd.y = imgRect.height - Mathf.Clamp(dragEnd.y, 0, imgRect.height);
					dragEnd.x = Mathf.Round(dragEnd.x / zoom);
					dragEnd.y = Mathf.Round(dragEnd.y / zoom);
				}
				else
				{
					dragStart = Vector3.zero;
				}

			}
			if (Input.GetKey("mouse 0"))
			{
				if (dragStart == Vector2.zero)
				{
					return;
				}
				dragEnd = mouse - new Vector2(imgRect.x, imgRect.y);
				dragEnd.x = Mathf.Clamp(dragEnd.x, 0, imgRect.width);
				dragEnd.y = imgRect.height - Mathf.Clamp(dragEnd.y, 0, imgRect.height);
				dragEnd.x = Mathf.Round(dragEnd.x / zoom);
				dragEnd.y = Mathf.Round(dragEnd.y / zoom);

				if (tool == Tool.Brush)
				{
					Brush(dragEnd, preDrag);
				}
				if (tool == Tool.Eraser)
				{
					Eraser(dragEnd, preDrag);
				}

			}
			if (Input.GetKeyUp("mouse 0") && dragStart != Vector2.zero)
			{
				if (tool == Tool.Line)
				{
					dragEnd = mouse - new Vector2(imgRect.x, imgRect.y);
					dragEnd.x = Mathf.Clamp(dragEnd.x, 0, imgRect.width);
					dragEnd.y = imgRect.height - Mathf.Clamp(dragEnd.y, 0, imgRect.height);
					dragEnd.x = Mathf.Round(dragEnd.x / zoom);
					dragEnd.y = Mathf.Round(dragEnd.y / zoom);
					Debug.Log("Draw Line");
					Drawing.NumSamples = AntiAlias;
					if (stroke.enabled)
					{
						baseTex = Drawing.DrawLine(dragStart, dragEnd, lineTool.width, col, baseTex, true, col2, stroke.width);
					}
					else
					{
						baseTex = Drawing.DrawLine(dragStart, dragEnd, lineTool.width, col, baseTex);
					}
				}
				dragStart = Vector2.zero;
				dragEnd = Vector2.zero;
			}
			preDrag = dragEnd;				
		}

		void Brush(Vector2 p1, Vector2 p2)
		{
			Drawing.NumSamples = AntiAlias;
			if (p2 == Vector2.zero)
			{
				p2 = p1;
			}
			Drawing.PaintLine(p1, p2, brush.width, col, brush.hardness, baseTex);
			baseTex.Apply();
		}

		void Eraser(Vector2 p1, Vector2 p2)
		{
			Drawing.NumSamples = AntiAlias;
			if (p2 == Vector2.zero)
			{
				p2 = p1;
			}
			Drawing.PaintLine(p1, p2, eraser.width, Color.white, eraser.hardness, baseTex);
			baseTex.Apply();
		}

		void test()
		{
			float startTime = Time.realtimeSinceStartup;
			var w = 100;
			var h = 100;
			var p1 = new Drawing.BezierPoint(new Vector2(10, 0), new Vector2(5, 20), new Vector2(20, 0));
			var p2 = new Drawing.BezierPoint(new Vector2(50, 10), new Vector2(40, 20), new Vector2(60, -10));
			var c = new Drawing.BezierCurve(p1.main, p1.control2, p2.control1, p2.main);
			p1.curve2 = c;
			p2.curve1 = c;
			Vector2 elapsedTime = new Vector2((Time.realtimeSinceStartup - startTime) * 10, 0);
			float startTime2 = Time.realtimeSinceStartup;
			for (var i = 0; i < w * h; i++)
			{
				Mathfx.IsNearBezier(new Vector2(Random.value * 80, Random.value * 30), p1, p2, 10);
			}

			Vector2 elapsedTime2 = new Vector2((Time.realtimeSinceStartup - startTime2) * 10, 0);
			Debug.Log("Drawing took " + elapsedTime.ToString() + "  " + elapsedTime2.ToString());

		}

		/* ===== Option for Tools ===== */

		public class LineTool
		{
			public float width = 1;
		}
		public class EraserTool
		{
			public float width = 10;
			public float hardness = 10;
		}
		public class BrushTool // Brush defining
		{
			public float width = 5;
			public float hardness = 20;
			public float spacing = 10;
		}
		public class Stroke
		{
			public bool enabled = false;
			public float width = 1;
		}
	}
	// }
}
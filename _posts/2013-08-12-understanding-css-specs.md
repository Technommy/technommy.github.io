---
layout: post
title: [译]理解 CSS 规范
date: 2013-11-25 11:01:00
---

<style>
body {
  font-family: Helvetica, arial, sans-serif;
  font-size: 14px;
  line-height: 1.6;
  padding-top: 10px;
  padding-bottom: 10px;
  background-color: white;
  padding: 30px; }

body > *:first-child {
  margin-top: 0 !important; }
body > *:last-child {
  margin-bottom: 0 !important; }

a {
  color: #4183C4;
  text-decoration: none; }
a.absent {
  color: #cc0000; }
a.anchor {
  display: block;
  padding-left: 30px;
  margin-left: -30px;
  cursor: pointer;
  position: absolute;
  top: 0;
  left: 0;
  bottom: 0; }

h1, h2, h3, h4, h5, h6 {
  margin: 20px 0 10px;
  padding: 0;
  font-weight: bold;
  -webkit-font-smoothing: antialiased;
  cursor: text;
  position: relative; }

h1:hover a.anchor, h2:hover a.anchor, h3:hover a.anchor, h4:hover a.anchor, h5:hover a.anchor, h6:hover a.anchor {
  background: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAA09pVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMy1jMDExIDY2LjE0NTY2MSwgMjAxMi8wMi8wNi0xNDo1NjoyNyAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENTNiAoMTMuMCAyMDEyMDMwNS5tLjQxNSAyMDEyLzAzLzA1OjIxOjAwOjAwKSAgKE1hY2ludG9zaCkiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6OUM2NjlDQjI4ODBGMTFFMTg1ODlEODNERDJBRjUwQTQiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6OUM2NjlDQjM4ODBGMTFFMTg1ODlEODNERDJBRjUwQTQiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDo5QzY2OUNCMDg4MEYxMUUxODU4OUQ4M0REMkFGNTBBNCIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDo5QzY2OUNCMTg4MEYxMUUxODU4OUQ4M0REMkFGNTBBNCIvPiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gPD94cGFja2V0IGVuZD0iciI/PsQhXeAAAABfSURBVHjaYvz//z8DJYCRUgMYQAbAMBQIAvEqkBQWXI6sHqwHiwG70TTBxGaiWwjCTGgOUgJiF1J8wMRAIUA34B4Q76HUBelAfJYSA0CuMIEaRP8wGIkGMA54bgQIMACAmkXJi0hKJQAAAABJRU5ErkJggg==) no-repeat 10px center;
  text-decoration: none; }

h1 tt, h1 code {
  font-size: inherit; }

h2 tt, h2 code {
  font-size: inherit; }

h3 tt, h3 code {
  font-size: inherit; }

h4 tt, h4 code {
  font-size: inherit; }

h5 tt, h5 code {
  font-size: inherit; }

h6 tt, h6 code {
  font-size: inherit; }

h1 {
  font-size: 28px;
  color: black; }

h2 {
  font-size: 24px;
  border-bottom: 1px solid #cccccc;
  color: black; }

h3 {
  font-size: 18px; }

h4 {
  font-size: 16px; }

h5 {
  font-size: 14px; }

h6 {
  color: #777777;
  font-size: 14px; }

p, blockquote, ul, ol, dl, li, table, pre {
  margin: 15px 0; }

hr {
  background: transparent url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAYAAAAECAYAAACtBE5DAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyJpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMC1jMDYwIDYxLjEzNDc3NywgMjAxMC8wMi8xMi0xNzozMjowMCAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENTNSBNYWNpbnRvc2giIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6OENDRjNBN0E2NTZBMTFFMEI3QjRBODM4NzJDMjlGNDgiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6OENDRjNBN0I2NTZBMTFFMEI3QjRBODM4NzJDMjlGNDgiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDo4Q0NGM0E3ODY1NkExMUUwQjdCNEE4Mzg3MkMyOUY0OCIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDo4Q0NGM0E3OTY1NkExMUUwQjdCNEE4Mzg3MkMyOUY0OCIvPiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gPD94cGFja2V0IGVuZD0iciI/PqqezsUAAAAfSURBVHjaYmRABcYwBiM2QSA4y4hNEKYDQxAEAAIMAHNGAzhkPOlYAAAAAElFTkSuQmCC) repeat-x 0 0;
  border: 0 none;
  color: #cccccc;
  height: 4px;
  padding: 0;
}

body > h2:first-child {
  margin-top: 0;
  padding-top: 0; }
body > h1:first-child {
  margin-top: 0;
  padding-top: 0; }
  body > h1:first-child + h2 {
    margin-top: 0;
    padding-top: 0; }
body > h3:first-child, body > h4:first-child, body > h5:first-child, body > h6:first-child {
  margin-top: 0;
  padding-top: 0; }

a:first-child h1, a:first-child h2, a:first-child h3, a:first-child h4, a:first-child h5, a:first-child h6 {
  margin-top: 0;
  padding-top: 0; }

h1 p, h2 p, h3 p, h4 p, h5 p, h6 p {
  margin-top: 0; }

li p.first {
  display: inline-block; }
li {
  margin: 0; }
ul, ol {
  padding-left: 30px; }

ul :first-child, ol :first-child {
  margin-top: 0; }

dl {
  padding: 0; }
  dl dt {
    font-size: 14px;
    font-weight: bold;
    font-style: italic;
    padding: 0;
    margin: 15px 0 5px; }
    dl dt:first-child {
      padding: 0; }
    dl dt > :first-child {
      margin-top: 0; }
    dl dt > :last-child {
      margin-bottom: 0; }
  dl dd {
    margin: 0 0 15px;
    padding: 0 15px; }
    dl dd > :first-child {
      margin-top: 0; }
    dl dd > :last-child {
      margin-bottom: 0; }

blockquote {
  border-left: 4px solid #dddddd;
  padding: 0 15px;
  color: #777777; }
  blockquote > :first-child {
    margin-top: 0; }
  blockquote > :last-child {
    margin-bottom: 0; }

table {
  padding: 0;border-collapse: collapse; }
  table tr {
    border-top: 1px solid #cccccc;
    background-color: white;
    margin: 0;
    padding: 0; }
    table tr:nth-child(2n) {
      background-color: #f8f8f8; }
    table tr th {
      font-weight: bold;
      border: 1px solid #cccccc;
      margin: 0;
      padding: 6px 13px; }
    table tr td {
      border: 1px solid #cccccc;
      margin: 0;
      padding: 6px 13px; }
    table tr th :first-child, table tr td :first-child {
      margin-top: 0; }
    table tr th :last-child, table tr td :last-child {
      margin-bottom: 0; }

img {
  max-width: 100%; }

span.frame {
  display: block;
  overflow: hidden; }
  span.frame > span {
    border: 1px solid #dddddd;
    display: block;
    float: left;
    overflow: hidden;
    margin: 13px 0 0;
    padding: 7px;
    width: auto; }
  span.frame span img {
    display: block;
    float: left; }
  span.frame span span {
    clear: both;
    color: #333333;
    display: block;
    padding: 5px 0 0; }
span.align-center {
  display: block;
  overflow: hidden;
  clear: both; }
  span.align-center > span {
    display: block;
    overflow: hidden;
    margin: 13px auto 0;
    text-align: center; }
  span.align-center span img {
    margin: 0 auto;
    text-align: center; }
span.align-right {
  display: block;
  overflow: hidden;
  clear: both; }
  span.align-right > span {
    display: block;
    overflow: hidden;
    margin: 13px 0 0;
    text-align: right; }
  span.align-right span img {
    margin: 0;
    text-align: right; }
span.float-left {
  display: block;
  margin-right: 13px;
  overflow: hidden;
  float: left; }
  span.float-left span {
    margin: 13px 0 0; }
span.float-right {
  display: block;
  margin-left: 13px;
  overflow: hidden;
  float: right; }
  span.float-right > span {
    display: block;
    overflow: hidden;
    margin: 13px auto 0;
    text-align: right; }

code, tt {
  margin: 0 2px;
  padding: 0 5px;
  white-space: nowrap;
  border: 1px solid #eaeaea;
  background-color: #f8f8f8;
  border-radius: 3px; }

pre code {
  margin: 0;
  padding: 0;
  white-space: pre;
  border: none;
  background: transparent; }

.highlight pre {
  background-color: #f8f8f8;
  border: 1px solid #cccccc;
  font-size: 13px;
  line-height: 19px;
  overflow: auto;
  padding: 6px 10px;
  border-radius: 3px; }

pre {
  background-color: #f8f8f8;
  border: 1px solid #cccccc;
  font-size: 13px;
  line-height: 19px;
  overflow: auto;
  padding: 6px 10px;
  border-radius: 3px; }
  pre code, pre tt {
    background-color: transparent;
    border: none; }

sup {
    font-size: 0.83em;
    vertical-align: super;
    line-height: 0;
}
* {
	-webkit-print-color-adjust: exact;
}
@media screen and (min-width: 914px) {
    body {
        width: 854px;
        margin:0 auto;
    }
}
@media print {
	table, pre {
		page-break-inside: avoid;
	}
	pre {
		word-wrap: break-word;
	}
}
</style>

<h1>理解 CSS 规范</h1>

<blockquote><p>就算你不是一名计算机科学系的学生，甚至不用满十八岁或拿到学士学位，都可以读懂 W3C 的 CSS 文档，前提是你得乐于钻研，能耐下心，以及注重细节。</p>

<p>另外记住，规范并不是手册，如果你找到了一些文法或相关理解层面上的错误，欢迎指正。</p></blockquote>

<h2>从零开始</h2>

<p><strong><a href="http://catcode.com/">J. David Eisenberg</a></strong> 之前有为网页设计人员写过一篇《<a href="http://m.alistapart.com/articles/readspec/">如何阅读 W3C 标准</a>》，大家不妨看看这篇为初学者准备的文章。</p>

<p>如果在此之前你完全不懂 CSS，建议先去网上搜阅资料了解一下，比如可以以 W3C 为初学者准备的 <a href="http://www.w3.org/TR/CSS21/">CSS 2.1</a> <a href="http://www.w3.org/TR/CSS21/intro.html">入门指南</a> 作为参考。但如果你想要更全面的了解 CSS，建议买本学习指南仔细阅读；记住，重点在理解 CSS 的基础上，而不是更多想着表面上的设计。找款文本编辑器，用所学的知识写个简单的网页，了解选择器权重（selector specificity）和外边距合并（margin collapsing），或者尝试加上这段 <code>{ border: 1px dashed gray; }</code> 代码到你的网页中以勾勒出一个盒模型（box model）。至此，只有读懂基础知识才能全面的理解规范。</p>

<h2>基础</h2>

<p>理解 CSS 规范需要从「上下文（context）」、「语汇（vocabulary）」和「基础概念」开始，如果希望能够读透这些规范，你必须完全理解以下几个部分：</p>

<ol>
<li>首先，通过阅读最新的「<a href="http://www.w3.org/TR/CSS/">CSS Snapshot</a>」来初步了解现有的规范是怎样的情况，另外还可以看看「<a href="http://www.w3.org/TR/CSS21/intro.html#design-principles">CSS 设计原理</a>」这一小节；</li>
<li>阅读 CSS 2.1 中的 <a href="http://www.w3.org/TR/CSS21/about.html">第一章</a>，当中解释了所有的 CSS 规范是如何整理的；</li>
<li>阅读 CSS 2.1 中的 <a href="http://www.w3.org/TR/CSS21/conform.html#defs">3.1</a> 小节（规范是如何定义的），了解 CSS 规范中常用的词汇；</li>
<li>仔细的阅读 CSS 2.1 中的以下几部分，因为其中的规章和概念能够向你详细解释 CSS 规范的实现意义：

<ul>
<li>「<a href="http://www.w3.org/TR/CSS21/cascade.html">指配属性值，层叠与继承</a>」第六章，特别是其中的 <a href="http://www.w3.org/TR/CSS21/cascade.html#value-stages">6.1</a> 和 <a href="http://www.w3.org/TR/CSS21/cascade.html#inheritance">6.2</a> 小节；</li>
<li>「<a href="http://www.w3.org/TR/CSS21/box.html#box-dimensions">盒尺寸</a>」8.1 小节；</li>
<li>「<a href="http://www.w3.org/TR/CSS21/visuren.html#visual-model-intro">可视化格式模型</a>」9.1 小节；</li>
<li>「<a href="http://www.w3.org/TR/CSS21/visuren.html#box-gen">控制框生成</a>」9.2 小节；</li>
<li>「<a href="http://www.w3.org/TR/CSS21/visuren.html#positioning-scheme">定位方案</a>」9.3 小节（副标题的内容）；</li>
<li>「<a href="http://www.w3.org/TR/CSS21/visudet.html#containing-block-details">包含块的定义</a>」10.1 小节；</li>
</ul>
</li>
</ol>


<p>在阅读规范的过程中，你可能会需要来回参考不同的文段来理解标准中某些字句相当晦涩的部分。</p>

<h2>一些重要的细节</h2>

<p>有些像 CSS 2.1 的 CSS 规范是有<em>勘误表</em>的，也就是在规范发布后才作出的纠正。<strong>当你在尝试解释规范中的某些定义时，一定要确保你看过了勘误表。</strong>虽然这些勘误并没有即时的放进规范正文中，但是这些纠正对规范至关重要，大家可以在每份规范的顶部找到勘误页面的链接。</p>

<h2>加深理解</h2>

<p>参与到编写规范工作本身是加深对其理解最好的方法（包括规范和规范所诠释的技术），尝试写一些测试案例，用你的代码解释为什么规范要这样写，如何起作用；或是加入 W3C 的 QA (Quality Assurance) 计划，从 CSS 社区中（比如文章作者、实现者以及规范作者）收获许多。重要的是，大家都可以通过编写／改进和对比不同的测试案例，以及回答有关测试案例的规范问题来学习并且向规范进行贡献。</p>

<blockquote><p><a href="http://www.w3.org/Style/CSS/Test/"><strong>W3C CSS 一致性测试套件</strong></a></p></blockquote>

<p>W3C 在为 CSS 规范维护官方的一致性测试套件。</p>

<blockquote><p><a href="http://www.mozilla.org/"><strong>Mozilla 项目组</strong></a></p></blockquote>

<p>Mozilla 项目组维护着其 Gecko 页面排版引擎，即 Firefox、Netscape、Seamonkey、Camino、Flock 和诸多桌面浏览器的核心。</p>

<blockquote><p><a href="http://www.webkit.org/"><strong>WebKit 项目组</strong></a></p></blockquote>

<p>Webkit 项目组维护着其 WebKit 页面排版引擎，即 Safari、Omniweb、iCab 和诸多桌面浏览器的核心。</p>

<blockquote><p><a href="http://www.konqueror.org/investigatebug/"><strong>KDE 项目组</strong></a></p></blockquote>

<p>KDE 项目组维护着其 KHTML 页面排版引擎，即 Konqueror 桌面浏览器的核心，也是 WebKit 引擎的原始代码奠基。</p>

<h2>提问</h2>

<p>如果你已经细读过规范，但还有些不明白的地方，可以发送问题至 <code>www-style</code> <a href="http://lists.w3.org/Archives/Public/www-style/">邮件列表</a>（需要先订阅）向 CSS 专家们请教。</p>

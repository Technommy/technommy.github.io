---
layout: post
title: Sphinx 開發者簡明使用指南
date: 2013-08-13 11:30:00
---

> 本文鏈接自 [Sphinx](http://technommy.github.io/2013/08/13/sphinx-developer-guide/) 官網後修改排版

<p>提到「引擎」，大家往往会想到复杂的开发框架，厚重的参考手册，不过，基于 Sphinx，HTML5 开发者并不需要有这些担心，因为 Sphinx 是一款提供标准 HTML5 接口的内核引擎。花半小时阅读一遍本文，HTML5 开发者完全可以掌握 Sphinx 的使用方法。</p>
<p>同时，我们提供了一个简单的案例</p>

<p><b style="background-color: #798796; padding-right: 3px;">&nbsp;</b>&nbsp;<a href="http://sphinx.oupeng.com/sphinxsample" target="_blank">基于 Sphinx 实现高性能 HTML5 手机游戏</a></p>

<p>开发者可以参考实际完成一款游戏基于 Sphinx 运行、调试、打包的过程。</p>

<p style="background-color: #d40000; color: #ffffff; font-size: 18px; padding-top: 3px; padding-bottom: 3px;"><b style="background-color: #ffffff; color: #d40000; padding-left: 5px; padding-right: 5px; font-size: 16px;">STEP 1</b>&nbsp;<b>了解 Sphinx 的应用模式</b></p>

<p>本质上，Sphinx 是一个经过了革命性优化的浏览器内核。它的基本应用模式是：与 HTML5/JavaScript 程序打包为.apk 可执行文件。开发者可以在 Sphinx 的 <a href="http://sphinx.oupeng.com/demo" target="_blank">DEMO</a> 页面 下载到基于 Sphinx 打包的一些 Demo，同时也可以对比同样的 Demo 基于传统手机浏览器运行的效果。</p>

<p style="background-color: #d40000; color: #ffffff; font-size: 18px; padding-top: 3px; padding-bottom: 3px;"><b style="background-color: #ffffff; color: #d40000; padding-left: 5px; padding-right: 5px; font-size: 16px;">STEP 2</b>&nbsp;<b>基于 Sphinx 开发程序</b></p>

<p>Sphinx 对开发工具，开发模式没有特殊限定；标准的 HTML5 应用都可以基于 Sphinx 运行。不过，不同浏览器内核对部分 HTML5 规范的实现细节各有不同。Sphinx 的规范遵从度细节请参考如下链接：</p>

<p><b style="background-color: #798796; padding-right: 3px;">&nbsp;</b>&nbsp;<a href="http://sphinx.oupeng.com/sphinxsample" target="_blank">Web specifications support in Opera Presto 2.12</a></p>
<p><b style="background-color: #798796; padding-right: 3px;">&nbsp;</b>&nbsp;<a href="http://sphinx.oupeng.com/sphinxsample" target="_blank">Sphinx 支持的 Web 标准</a></p>

<p>开发者也可以在一些中文网站如 <a href="http://www.w3school.com.cn/" target="_blank">W3School</a> 查询到具体规范细节在不同浏览器的遵从度，Sphinx 的规范遵从度等同于 Opera。</p>

<p style="background-color: #d40000; color: #ffffff; font-size: 18px; padding-top: 3px; padding-bottom: 3px;"><b style="background-color: #ffffff; color: #d40000; padding-left: 5px; padding-right: 5px; font-size: 16px;">STEP 3</b>&nbsp;<b>基于 Sphinx 调试和调优</b></p>

<p>Sphinx 提供如下调试工具：</p>

<p><b style="background-color: #16a085; color: #ffffff; padding-right: 4px; padding-left: 4px; border-radius: 5px;">1</b><b style="color: #16a085; padding-left: 4px; padding-right: 4px;">Sphinx 模拟器</b></p>

<p><b style="background-color: #16a085; color: #ffffff; padding-right: 4px; padding-left: 4px; border-radius: 5px;">2</b><b style="color: #16a085; padding-left: 4px; padding-right: 4px;">Opera 12 浏览器</b></p>

<p>Sphinx 模拟器和 Opera 12 浏览器的具体使用办法请参考《<a href="http://sphinx.oupeng.com/developer-guide" target="_blank">开发工具说明</a>》，概括而言，上述工具主要有如下 3 种应用方法：</p>

<p><b style="background-color: #16a085; color: #16a085; padding-right: 2px;">0</b>&nbsp;<b style="color: #16a085; padding-right: 2px;">1</b><b style="background-color: #16a085; color: #ffffff; padding-left: 4px; padding-right: 4px;">模拟运行</b></p>

<p>Sphinx 模拟器提供传统浏览器的操作模式，开发者可以通过 URL 方式指定运行程序，其运行效果等同于 Sphinx 打包运行效果。</p>

<p><b style="background-color: #16a085; color: #16a085; padding-right: 2px;">0</b>&nbsp;<b style="color: #16a085; padding-right: 2px;">2</b><b style="background-color: #16a085; color: #ffffff; padding-left: 4px; padding-right: 4px;">DEBUG</b></p>

<p>Opera 12 浏览器与 Sphinx 模拟器配合使用，可以通过 “远程调试” 的方式 debug 在 Sphinx 模拟器中运行的 HTML5/JavaScript 代码。其操作方式等同于 Opera 浏览器的开发者工具 Dragonfly。</p>

<p><b style="background-color: #16a085; color: #16a085; padding-right: 2px;">0</b>&nbsp;<b style="color: #16a085; padding-right: 2px;">3</b><b style="background-color: #16a085; color: #ffffff; padding-left: 4px; padding-right: 4px;">性能分析</b></p>

<p>在 Opera 12 浏览器的 Dragonfly 工具栏中选择 Profiler 菜单，可以针对在 Sphinx 模拟器中运行的 JavaScript 代码进行 Profiler 分析。</p>

<p style="background-color: #cccccc; font-size: 13px; padding-bottom: 10px; padding-top: 10px;"><b style="background-color: #898989; color: #ffffff; padding-left: 3px; padding-right: 3px; border-radius: 2px;">提示</b>&nbsp;Sphinx 模拟器还有一个小机关，在 Sphinx 模拟器的运行手机 SD 卡根目录中存放一个名为 fps.ini 的空白文件，启动运行 Sphinx 模拟器，其左上角会出现一条文为 “fps ***” 的小 banner，它表示当前 GPU 的运行帧率。</p>

<p>GPU 的帧率受制于 JavaScript 程序的调用频率。如果程序帧率设定合理（游戏程序帧率至多不应超过 60 fps）：大部分情况下，GPU 的运行帧率都会等于当前 JavaScript 程序的运行帧率，同时，若此帧率明显低于程序的设定帧率，则说明当前程序的性能瓶颈主要在 CPU 运算即上层 JavaScript 的运行上；如果 GPU 的运行帧率明显低于当前 JavaScript 程序的运行帧率，则说明当前程序可能卡在了 GPU 渲染上。</p>

<p>HTML5/JavaScript 程序要在手机上呈现出色的运行效果，其关键路径即每一帧的运行效率非常重要。概括而言，如下一些 HTML5 程序应用模式对于优化 HTML5/JavaScript 程序性能是比较干货的：</p>

<p><b style="background-color: #16a085; color: #16a085; padding-right: 2px;">0</b>&nbsp;<b style="color: #16a085; padding-right: 2px;">1</b><b style="background-color: #16a085; color: #ffffff; padding-left: 4px; padding-right: 4px;">渲染层面的性能优化</b></p>

<p><b style="background-color: #2980b9; color: #ffffff; padding-left: 4px; padding-right: 4px;">A</b>&nbsp;<b style="color: #2980b9;">直接在页面 canvas 进行渲染，不要使用间接手段</b></p>

<p>Sphinx 基于硬件渲染实现 canvas 渲染，基于 Sphinx，不需要采用 “缓存 canvas” 等间接描绘方法，同时，更不建议使用 getImageData、putImageData 方法。有关于此，可以阅读博文《<a href="http://sphinx.oupeng.com/articles/the-stories-about-getimagedata-and-putimagedata" target="_blank">getImageData 背后的故事</a>》。如果程序不得不使用这些方法，那么至少应当注意，不要在每一帧都进行 canvas 缓存、getImageData、putImageData 的操作。</p>

<p><b style="background-color: #2980b9; color: #ffffff; padding-left: 4px; padding-right: 4px;">B</b>&nbsp;<b style="color: #2980b9;">减少无谓的 Canvas API调用</b></p>

<p>游戏程序会在每一帧进行数十个或数百个对象的描绘，且可能针对部分对象进行缩放，移动，旋转等操作。在此过程中，某些 Canvas API 可能是没有意义的。例如，如果某个对象并不需要进行缩放、位移、旋转变化，即变换参数是 (1, 0, 0, 1, 0, 0)，那么，调用 transform 就没有意义；如果前后 2 个对象的变换参数完全相同，那么针对后一个对象进行　restore、save、transform　等操作就是多余的。</p>

<p><b style="background-color: #16a085; color: #16a085; padding-right: 2px;">0</b>&nbsp;<b style="color: #16a085; padding-right: 2px;">2</b><b style="background-color: #16a085; color: #ffffff; padding-left: 4px; padding-right: 4px;">JavaScript 层面的性能优化</b></p>

<p>JavaScript 是弱类型语言，它提供了非常灵活的数据定义方式，这种灵活是以 JavaScript 引擎的负担为代价的，这些负担可能表现为：</p>

<p><b style="background-color: #2980b9; color: #ffffff; padding-left: 4px; padding-right: 4px;">JIT 的代价</b>&nbsp;数据类型的改变，对象属性的改变导致 JavaScript 引擎被迫管理更多的对象类型结构，甚至被迫进行重编译；</p>

<p><b style="background-color: #2980b9; color: #ffffff; padding-left: 4px; padding-right: 4px;">GC 的代价</b>&nbsp;过分零碎的对象数据块，可能带来更多的 GC 运行负担，等等</p>

<p>高效的应用程序应当尽量避免增大 JavaScript 引擎运行负担的应用模式，例如：</p>

<p><b style="background-color: #2980b9; color: #ffffff; padding-left: 4px; padding-right: 4px;">A</b>&nbsp;<b style="color: #2980b9;">采用静态的对象构建模型</b></p>

<p>游戏程序往往会采用面向对象的程序模式，应尽量采用静态方式维护对象模型，比如：不要在初始化方法以外的方法中进行对象属性增删操作；不要采用 prototype 方式构建可写属性；不要频繁进行对象创建和释放操作，特别是不要在每一帧（关键路径）都进行频繁的对象创建操作。</p>

<p><b style="background-color: #2980b9; color: #ffffff; padding-left: 4px; padding-right: 4px;">B</b>&nbsp;<b style="color: #2980b9;">避免一些明显的性能风险</b></p>

<p>例如：不要采用超长方法（例如，超过 800～1000 行的方法），尽量少用 eval。</p></p>

<p style="background-color: #d40000; color: #ffffff; font-size: 18px; padding-top: 3px; padding-bottom: 3px;"><b style="background-color: #ffffff; color: #d40000; padding-left: 5px; padding-right: 5px; font-size: 16px;">STEP 4</b>&nbsp;<b>技术社区</b></p>

<p>Sphinx 面向开发者提供如下技术交流的平台，开发者可以提问，交流，发表，吐槽 Sphinx 应用方法和体验，以及在 HTML5、Canvas API、JavaScript 等领域的应用经验</p>

<p><b style="background-color: #798796; padding-right: 3px;">&nbsp;</b>&nbsp;<a href="http://sphinx.oupeng.com/sphinxsample" target="_blank">Sphinx 论坛</a></p>

<p><b style="background-color: #798796; padding-right: 3px;">&nbsp;</b>&nbsp;<a href="http://sphinx.oupeng.com/sphinxsample" target="_blank">Sphinx 博客</a></p>

<p><b style="background-color: #798796; padding-right: 3px;">&nbsp;</b>&nbsp;<a href="http://sphinx.oupeng.com/sphinxsample" target="_blank">Sphinx 联系邮箱</a></p>

<p style="background-color: #d40000; color: #ffffff; font-size: 18px; padding-top: 3px; padding-bottom: 3px;"><b style="background-color: #ffffff; color: #d40000; padding-left: 5px; padding-right: 5px; font-size: 16px;">STEP 5</b>&nbsp;<b>开发者平台</b></p>

<p>开发者可以在 Sphinx 开发者平台获得如下服务：</p>

<p><b style="background-color: #798796; padding-right: 3px;">&nbsp;</b>&nbsp;<a href="http://sphinx.oupeng.com/sphinxsample" target="_blank">注册，管理游戏</a></p>

<p><b style="background-color: #798796; padding-right: 3px;">&nbsp;</b>&nbsp;<a href="http://sphinx.oupeng.com/sphinxsample" target="_blank">自动打包</a></p>

<p>后续，Sphinx 还将提供灵活的支付，广告等功能和手段，帮助开发者快速更便捷地实现商业盈利。
开发者也可以通过 Sphinx 邮箱与我们联系具体的商业合作。</p>

<p>HTML5 是移动应用的技术趋势之一，性能问题是 HTML5 移动应用面临的行业性瓶颈。Opera／欧朋是全球最大的手机浏览器提供商，也是极少数完整具备内核技术的厂商。Sphinx 的开发团队是一帮有极客精神的技术控，我们非常希望与开发者群体一起，共同探寻突破 HTML5 手机应用技术瓶颈的道路，共同实现 HTML5 手机应用和手机游戏的商业成功。</p>


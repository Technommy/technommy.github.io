---
layout: post
title: Understanding the CSS Specifications
date: 2013-12-01 04:01:00
---

#【译】理解 CSS 规范

> 就算你不是一名计算机科学系的学生，甚至不用满十八岁或拿到学士学位，都可以读懂 W3C 的 CSS 文档，前提是你得乐于钻研、能耐下心，以及对细节缜密。

> 另外记住，规范并不是手册，如果你找到了一些文法或相关理解层面上的错误，欢迎指正。

##从零开始
__[J. David Eisenberg](http://catcode.com/)__ 之前有为网页设计人员写过一篇《[如何阅读 W3C 标准](http://m.alistapart.com/articles/readspec/)》，大家不妨看看这篇为初学者准备的文章。

如果在此之前你完全不懂 CSS，建议先去网上搜阅资料了解一下，比如可以以 W3C 为初学者准备的 [CSS 2.1](http://www.w3.org/TR/CSS21/) [入门指南](http://www.w3.org/TR/CSS21/intro.html) 作为参考。但如果你想要更全面的了解 CSS，建议买本学习指南仔细阅读；记住，重点在理解 CSS 的基础上，而不是更多想着表面上的设计。找款文本编辑器，用所学的知识写个简单的网页，了解选择器权重（selector specificity）和外边距合并（margin collapsing），或者尝试加上这段 ``{ border: 1px dashed gray; }`` 代码到你的网页中以勾勒出一个盒模型（box model）。至此，只有读懂基础知识才能全面的理解规范。

##基础
理解 CSS 规范需要从「上下文（context）」、「语汇（vocabulary）」和「基础概念」开始，如果希望能够读透这些规范，你必须完全理解以下几个部分：

1. 首先，通过阅读最新的「[CSS Snapshot](http://www.w3.org/TR/CSS/)」来初步了解现有的规范是怎样的情况，另外还可以看看「[CSS 设计原理](http://www.w3.org/TR/CSS21/intro.html#design-principles)」这一小节；
2. 阅读 CSS 2.1 中的 [第一章](http://www.w3.org/TR/CSS21/about.html)，当中解释了所有的 CSS 规范是如何整理的；
3. 阅读 CSS 2.1 中的 [3.1](http://www.w3.org/TR/CSS21/conform.html#defs) 小节（规范是如何定义的），了解 CSS 规范中常用的词汇；
4. 仔细的阅读 CSS 2.1 中的以下几部分，因为其中的规章和概念能够向你详细解释 CSS 规范的实现意义：
    * 「[指配属性值，层叠与继承](http://www.w3.org/TR/CSS21/cascade.html)」第六章，特别是其中的 [6.1](http://www.w3.org/TR/CSS21/cascade.html#value-stages) 和 [6.2](http://www.w3.org/TR/CSS21/cascade.html#inheritance) 小节；
    * 「[盒尺寸](http://www.w3.org/TR/CSS21/box.html#box-dimensions)」8.1 小节；
    * 「[可视化格式模型](http://www.w3.org/TR/CSS21/visuren.html#visual-model-intro)」9.1 小节；
    * 「[控制框生成](http://www.w3.org/TR/CSS21/visuren.html#box-gen)」9.2 小节；
    * 「[定位方案](http://www.w3.org/TR/CSS21/visuren.html#positioning-scheme)」9.3 小节（副标题的内容）；
    * 「[包含块的定义](http://www.w3.org/TR/CSS21/visudet.html#containing-block-details)」10.1 小节；

在阅读规范的过程中，你可能会需要来回参考不同的文段来理解标准中某些字句相当晦涩的部分。

##一些重要的细节
有些像 CSS 2.1 的 CSS 规范是有_勘误表_的，也就是在规范发布后才作出的纠正。__当你在尝试解释规范中的某些定义时，一定要确保你看过了勘误表。__虽然这些勘误并没有即时的放进规范正文中，但是这些纠正对规范至关重要，大家可以在每份规范的顶部找到勘误页面的链接。

##加深理解
参与到编写规范工作本身是加深对其理解最好的方法（包括规范和规范所诠释的技术），尝试写一些测试案例，用你的代码解释为什么规范要这样写，如何起作用；或是加入 W3C 的 QA (Quality Assurance) 计划，从 CSS 社区中（比如文章作者、实现者以及规范作者）收获许多。重要的是，大家都可以通过编写／改进和对比不同的测试案例，以及回答有关测试案例的规范问题来学习并且向规范进行贡献。

> [__W3C CSS 一致性测试套件__](http://www.w3.org/Style/CSS/Test/)

W3C 在为 CSS 规范维护官方的一致性测试套件。

> [__Mozilla 项目组__](http://www.mozilla.org/)

Mozilla 项目组维护着其 Gecko 页面排版引擎，即 Firefox、Netscape、Seamonkey、Camino、Flock 和诸多桌面浏览器的核心。

> [__WebKit 项目组__](http://www.webkit.org/)

Webkit 项目组维护着其 WebKit 页面排版引擎，即 Safari、Omniweb、iCab 和诸多桌面浏览器的核心。

> [__KDE 项目组__](http://www.konqueror.org/investigatebug/)

KDE 项目组维护着其 KHTML 页面排版引擎，即 Konqueror 桌面浏览器的核心，也是 WebKit 引擎的原始代码奠基。

##提问
如果你已经细读过规范，但还有些不明白的地方，可以发送问题至 ``www-style`` [邮件列表](http://lists.w3.org/Archives/Public/www-style/)（需要先订阅）向 CSS 专家们请教。

> This articles has been published on W3C China website
> <a href="http://www.chinaw3c.org/archives/369/">http://www.chinaw3c.org/archives/369/</a>

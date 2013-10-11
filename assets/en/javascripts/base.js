/**
 * base.js 全局js文件
 * Date 2013-06-20
 * Author qil
 *
 */
$(function(){
    $('#debug-down').on('click',function(e){
        e.preventDefault();
        if(!$('.down-box').length){
            $('#main').prepend('<div class="down-box"><span class="delete" id="delete"></span><h3>Choose a version according to your operating system</h3><div class="pl_item win"><a href="http://sphinx.oupeng.com//debug-tools/Opera_1215_int_Setup.exe" class="cover">windows</a></div><div class="pl_item linux"><a class="cover">linux</a><div class="links_down"><a href="http://sphinx.oupeng.com//debug-tools/opera_12.15.1748_amd64.deb">x86-64</a><a href="http://sphinx.oupeng.com//debug-tools/opera-10.63-6450.ppc.rpm">PowerPC</a><a href="http://sphinx.oupeng.com/debug-tools/opera_12.15.1748_i386.deb">i386</a></div></div><div class="pl_item mac"><a href="http://sphinx.oupeng.com//debug-tools/Opera_12.15-1748.x86_64.dmg" class="cover">mac版</a></div></div>');
            $('.down-box').fadeIn('fast');
        }
    });
    //隐藏下载框
    $('#delete').live('click',function(){
        $(this).closest('.down-box').remove();
    });

    var sliders = $('#banner').find('.item'),
        f_img = sliders.eq(0);
    function autoPlay() {
        var cur_img = $('#banner').find('.cur'),
            next = cur_img.next();
            thumbs = $('.navigation a');
        cur_img.stop().animate({
            "opacity" : 0
        }, 600, function() {
            $(this).removeClass('cur');
        });

        if (!next[0]) {
            next = f_img;
        }
        next.stop().animate({
            "opacity" : 1
        }, 600, function() {
            $(this).addClass('cur');
        });

        thumbs.removeClass('selected').eq(next.index()).addClass('selected');
    }



    var autoSlide = setInterval(autoPlay, 3000);


    $('.navigation a').on('click', function(e) {
        e.preventDefault();
        clearInterval(autoSlide);
        var index = $(this).index(), cur_img = $('#banner').find('.cur');

        $(this).addClass('selected').siblings().removeClass('selected');

        cur_img.stop().animate({
            "opacity" : 0
        }, 600, function() {
            $(this).removeClass('cur');
        });
        sliders.eq(index).stop().animate({
            "opacity" : 1
        }, 600, function() {
            $(this).addClass('cur');
            autoSlide = setInterval(autoPlay, 3000);
        });
    });
});
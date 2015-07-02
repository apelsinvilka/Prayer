$(document).ready(function() {
    
    TweenMax.from($("#logo"), 0.6, {opacity:0, delay:0.4, ease:Power2.easeOut, y:-200});
    TweenMax.from($("#panel"), 0.6, {opacity:0, delay:0.6, ease:Power2.easeOut, y:200});
    
    var textCreate = function () {
        
        var strPrayer = '';
        $('#bar').children().each(function (i, elem) {
            var strSpace = '';
            debugger
            if (strPrayer === '') {
                strSpace = '';
            } else { strSpace = ' ' }

            strPrayer += strSpace + $(elem).text();

        });

        $('#PrayerText').val(strPrayer);
    }
    
    $("#breathing-arrow").click(function() {
        $("html, body").animate({scrollTop: $("#home1").offset().top}, 500);
    }); 
        
    $("#btn1").click(function(){
        $("#home2").slideDown();
        $("#btn1").fadeOut();
        $("html, body").animate({ scrollTop: $("#home2").offset().top }, 500);

        textCreate();

    });
    
        $("#btn2").click(function(){
        $("#home3").slideDown();
        $("footer").slideDown();
        $("#home1").fadeOut();
        $("#home2").fadeOut();
        $("html, body").animate({ scrollTop: $("#home3").offset().top }, 500);
        textCreate();
    });

        $("#btn4").click(function(){
        $("#home1").fadeIn();
        $("#btn1").fadeIn();
        $("#home3").fadeOut();
        $("footer").fadeOut();
        $("html, body").animate({ scrollTop: $("#home1").offset().top }, 500);
        textCreate();
    });
    
        //$('#prayerCreate').click(function () {
        //    debugger

            


        //});

});
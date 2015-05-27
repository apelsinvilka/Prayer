$(document).ready(function() {
    
    TweenMax.from($("#logo"), 0.6, {opacity:0, delay:0.4, ease:Power2.easeOut, y:-200});
    TweenMax.from($("#panel"), 0.6, {opacity:0, delay:0.6, ease:Power2.easeOut, y:200});
    
    
    $("#breathing-arrow").click(function() {
        $("html, body").animate({scrollTop: $("#home1").offset().top}, 500);
    }); 
        
    $("#btn1").click(function(){
        $("#home2").slideDown();
        $("#btn1").fadeOut();
        $("html, body").animate({scrollTop: $("#home2").offset().top}, 500);
    });
    
        $("#btn2").click(function(){
        $("#home3").slideDown();
        $("footer").slideDown();
        $("#home1").fadeOut();
        $("#home2").fadeOut();
        $("html, body").animate({scrollTop: $("#home3").offset().top}, 500);
    });

        $("#btn4").click(function(){
        $("#home1").fadeIn();
        $("#btn1").fadeIn();
        $("#home3").fadeOut();
        $("footer").fadeOut();
        $("html, body").animate({scrollTop: $("#home1").offset().top}, 500);
    });
    
});
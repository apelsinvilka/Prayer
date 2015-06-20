$(document).ready(function() {
    var offset=630, // At what pixels show Back to Top Button
    scrollDuration=500; // Duration of scrolling to top
    $(window).scroll(function () {
        var regbutton = $('.regbutton');
	    if ($(this).scrollTop() > offset) {
	        regbutton.fadeIn(500); // Time(in Milliseconds) of appearing of the Button when scrolling down.
                } else {
	        regbutton.fadeOut(500); // Time(in Milliseconds) of disappearing of Button when scrolling up.
	        //regbutton.html('&#946;&#935;&#959;&#916;');
		}
	});
  /*$('.regbutton').click(function(event) {
	event.preventDefault();
            $('html, body').animate({
	        scrollTop: 0}, scrollDuration);
                })*/
	});
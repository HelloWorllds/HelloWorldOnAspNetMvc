var displayedNoteContent = null;


$(document).ready(function () {
    $("#datepickerMain").datepicker({
        inline: true,
        onSelect: function (dateText, obj) {
            //alert(dateText);

            //$.ajax({
            //    type: "POST",
            //    url: "/Calendar/Events",
            //    data: { Date: dateText }
            //}).done(function () {
            //    document.location.href = "/Calendar/Events";
            //}).fail(function (jqXHR, textStatus) {
            //    alert("Request failed: " + textStatus);
            //});

            $('#dateID').val(dateText);
        }
    });
    $.datepicker.setDefaults($.datepicker.regional["ru"]);
    
    if ($('.radio').is(':checked')) {
        setInterval(function () { $("#calendarSubmit").click() }, 2500);
    }
    else {
        setInterval(function () { $("#calendarSubmit").click() }, 500);
    }
    //setInterval(function () { $("#calendarSubmit").click() }, 500);

    //$(".item").on('click', function () {
    //    if (displayedNoteContent != null)
    //        displayedNoteContent.css('display', 'none');
    //    var id = $(this).attr('id');
    //    var replaceWhiteSpace = id.replace(" ", ".");
    //    displayedNoteContent = $("." + replaceWhiteSpace);
    //    displayedNoteContent.css('display', 'block');
    //});
});
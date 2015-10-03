var displayedNoteContent = null;
var NoteName = null;
var NoteContent = null;
var Notet = null;

$(document).ready(function () {
    $("#toggle-sidebar").click(function () {
        $('.ui.sidebar').sidebar('toggle');
    });

    $(".name").on('click', function () {
        if (displayedNoteContent != null)
            displayedNoteContent.css('display', 'none');
        var id = $(this).attr('id');
        var replaceWhiteSpace = id.replace(" ",".");
        displayedNoteContent = $("." + replaceWhiteSpace);
        displayedNoteContent.css('display', 'block');
    });

    $("#UnhideRadio").on('click', function () {
        $('.ui.slider.checkbox').toggle('slow');
    });

    $("#UnhideRadioYT").on('click', function () {
        $('.ui.slider.checkbox').toggle('slow');
    });

    $("#toggle-modal").click(function () {
        $('#AddModal').modal({
            closable: false,
            onDeny: function () {
                return true;
            },
            onApprove: function initAddPopup(modal) {
                $.ajax({
                    type: "POST",
                    url: "/Passwords/Add",
                    data: { Login: $("#Login").val(), Password: $("#Password").val(), Resource: $("#Resource").val() },
                    success: function () {
                        
                    },
                    failure: function (errMsg) {

                    }
                }).done(function () {
                    window.location.reload();
                }).fail(function (jqXHR, textStatus) {
                    alert("Request failed: " + textStatus);
                });
            }
        }).modal('show');
    });

    $("#toggle-del-modal").click(function () {
        var radioVal = $('input[name=radiot]:checked').val();
        if (radioVal == null) {
            $('#EmptyModal').modal({
                closable: false,
                onDeny: function () {
                    return true;
                }
            }).modal('show');
        }
        else {
            $('#DelModal').modal({
                closable: false,
                onDeny: function () {
                    return true;
                },
                onApprove: function initAddPopup(modal) {
                    $.ajax({
                        type: "POST",
                        url: "/Passwords/Del",
                        data: { ID: $('input[name=radiot]:checked').val() },
                        success: function (data) {
                            window.location.reload("/Passwords");
                        },
                        failure: function (errMsg) {

                        }
                    }).done(function () {
                        window.location.reload();
                    }).fail(function (jqXHR, textStatus) {
                        alert("Request failed: " + textStatus);
                    });
                }
            }).modal('show');
        }        
    });

    $("#AddBookmark").click(function () {
        $('#AddModalBM').modal({
            closable: false,
            onDeny: function () {
                return true;
            },
            onApprove: function initAddPopup(modal) {
                $.ajax({
                    type: "POST",
                    url: "/Bookmarks/Add",
                    data: { Name: $("#Name").val(), Url: "http://" + $("#Url").val() },
                    success: function (data) {
                        window.location.reload("/Bookmarks");
                    },
                    failure: function (errMsg) {

                    }
                }).done(function () {
                    window.location.reload();
                }).fail(function (jqXHR, textStatus) {
                    alert("Request failed: " + textStatus);
                });
            }
        }).modal('show');
    });

    $(".DelBookmarkLink").click(function () {
        var radioVal = $(this).attr('id');
        if (radioVal == null) {
            $('#EmptyModalBM').modal({
                closable: false,
                onDeny: function () {
                    return true;
                }
            }).modal('show');
        }
        else {
            $('#DelModalBM').modal({
                closable: false,
                onDeny: function () {
                    return true;
                },
                onApprove: function initAddPopup(modal) {
                    $.ajax({
                        type: "POST",
                        url: "/Bookmarks/Del",
                        data: { ID: radioVal },
                        success: function (data) {
                            window.location.reload("/Bookmarks");
                        },
                        failure: function (errMsg) {

                        }
                    }).done(function () {
                        window.location.reload();
                    }).fail(function (jqXHR, textStatus) {
                        alert("Request failed: " + textStatus);
                    });
                }
            }).modal('show');
        }
    });

    $("#AddVideo").click(function () {
        $('#AddModalYT').modal({
            closable: false,
            onDeny: function () {
                return true;
            },
            onApprove: function initAddPopup(modal) {
                var link = $("#YTUrl").val();
                var ytID = link.split('=');
                
                $.ajax({
                    type: "POST",
                    url: "/YouTubeLinks/Add",
                    data: { Name: $("#Name").val(), YTUrl: "https://www.youtube.com/embed/" + ytID[1], Description: $("#Description").val() },
                    success: function (data) {
                        window.location.reload("/YouTubeLinks");
                    },
                    failure: function (errMsg) {

                    }
                }).done(function () {
                    window.location.reload();
                }).fail(function (jqXHR, textStatus) {
                    alert("Request failed: " + textStatus);
                });
            }
        }).modal('show');
    });

    $(".DelYTLink").click(function () {
        var radioVal = $(this).attr('id');
        if (radioVal == null) {
            $('#EmptyModalYT').modal({
                closable: false,
                onDeny: function () {
                    return true;
                }
            }).modal('show');
        }
        else {
            $('#DelModalYT').modal({
                closable: false,
                onDeny: function () {
                    return true;
                },
                onApprove: function initAddPopup(modal) {
                    $.ajax({
                        type: "POST",
                        url: "/YouTubeLinks/Del",
                        data: { ID: radioVal },
                        success: function (data) {
                            window.location.reload("/YouTubeLinks");
                        },
                        failure: function (errMsg) {

                        }
                    }).done(function () {
                        window.location.reload();
                    }).fail(function (jqXHR, textStatus) {
                        alert("Request failed: " + textStatus);
                    });
                }
            }).modal('show');
        }
    });

    $('.InfoYTLink').popup({
        position: 'bottom center',
        target: '#infoIcon'
    });

    tinymce.init({
        mode: "textareas",
        theme: "modern",
        language:"ru",
        plugins: [
         "advlist autolink link lists charmap print preview hr anchor pagebreak spellchecker",
         "searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime nonbreaking",
         "save table contextmenu directionality emoticons template paste textcolor"
        ]
    });

    $(".DelNote").on('click', function () {
        var radioVal = $(this).attr('id');
        $('#DelModalNote').modal({
            closable: false,
            onDeny: function () {
                return true;
            },
            onApprove: function initAddPopup(modal) {
                $.ajax({
                    type: "POST",
                    url: "/Notes/Del",
                    data: { ID: radioVal },
                    success: function (data) {
                        window.location.reload("/Notes");
                    },
                    failure: function (errMsg) {

                    }
                }).done(function () {
                    window.location.reload();
                }).fail(function (jqXHR, textStatus) {
                    alert("Request failed: " + textStatus);
                });
            }
        }).modal('show');        
    });

    $('#NewNote').click(function () {
        $.cookie('note_name', null);
        $.cookie('note_content', null);
        tinyMCE.activeEditor.setContent("");
    });

    $("#AddNote").click(function () {
        $.ajax({
            type: "POST",
            url: "/Notes/Add",
            data: { Name: $("#Name").val(), Content: tinyMCE.activeEditor.getContent() }
        }).done(function () {
            document.location.href = "/Notes";
        }).fail(function (jqXHR, textStatus) {
            alert("Request failed: " + textStatus);
        });
    });

    //$('body').on('click', '.FullNote', function (e) {
    //    e.preventDefault();
    //    $(this).attr('data-toggle', '#FullModalNote');
    //});

    $(".FullNote").click(function () {
        $('#FullModalNote').modal('show');
    });

    var Name = null;
    var Content = null;

    $(".EditNote").click(function () {
        NoteName = $(this).attr('id');
        NoteContent = $(this).attr('name');
        
        $.cookie('note_name', NoteName);
        $.cookie('note_content', NoteContent);

        //$.ajax({
        //    url: '/Notes/Edit',
        //    type: 'POST',
        //    data: window.location.href = '/Notes/Edit',
        //    dataType: 'html'
        //}).done(function () {
            
        //}).fail(function (jqXHR, textStatus) {
        //    alert("Request failed: " + textStatus);
        //});
    });

    function parseUrlQuery() {
        var data = {};
        if (location.search) {
            var pair = (location.search.substr(1)).split('&');
            for (var i = 0; i < pair.length; i++) {
                var param = pair[i].split('=');
                data[param[0]] = param[1];
            }
        }
        return data;
    }
    
    window.onload = function () {
        $('#EditName').val($.cookie('note_name'));
        $('#EditEditor').val(tinyMCE.activeEditor.setContent($.cookie('note_content')));
    }

    $("#EditNotes").click(function () {
        var content = tinyMCE.activeEditor.getContent();
        var name = $('#EditName').val();
        
        $.ajax({
            type: "POST",
            url: "/Notes/Edit",
            data: { Name: name, Content: content }
        }).done(function () {            
            document.location.href = "/Notes";
        }).fail(function (jqXHR, textStatus) {
            alert("Request failed: " + textStatus);
        });

        $.cookie('note_name', null);
        $.cookie('note_content', null);
        tinyMCE.activeEditor.setContent("");
    });

    function str_rand(passlenght) {
        var result = '';
        var words = '0123456789qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM!@#$%^&*()';
        var max_position = words.length - 1;
        for (i = 0; i < passlenght; ++i) {
            position = Math.floor(Math.random() * max_position);
            result = result + words.substring(position, position + 1);
        }
        return result;
    }

    $("#gen").click(function () {
        $("#Password").val(str_rand(document.getElementById('passwlen').value));
    });

    //$("#dddd").click(function () {
    //    var hour = $("#Hours").val();
    //    var minutes = $("#Minutes").val();
    //    var str = "";
    //    str = (hour < 10) ? "0" + hour : hour;
    //    alert(str + ":"  + minutes);
    //});

    $("#datepickerAdd").datepicker({
        
    });

    $.datepicker.setDefaults($.datepicker.regional["ru"]);

    $("#AddCalendar").click(function () {
        $('#AddModalCalendar').modal({
            closable: false,
            onDeny: function () {
                return true;
            },
            onApprove: function initAddPopup(modal) {
                var hour = $("#Hours").val();
                var minutes = $("#Minutes").val();
                var str = "";
                str = (hour < 10) ? "0" + hour : hour;
                var strm = "";
                strm = (minutes == 0) ? "0" + minutes : minutes;
                //alert(str + ":" + strm);

                var day = $("#Day").val();
                var month = $("#Month").val();
                var year = $("#Year").val();


                var date = day + "." + month + "." + year;
                //alert(date);
                $.ajax({
                    type: "POST",
                    url: "/Calendar/Add",
                    data: { Date: date, Time: str + ":" + minutes, Description: $("#Description").val() },
                    success: function (data) {
                        window.location.reload("/YouTubeLinks");
                    },
                    failure: function (errMsg) {

                    }
                }).done(function () {
                    window.location.reload();
                }).fail(function (jqXHR, textStatus) {
                    alert("Request failed: " + textStatus);
                });
            }
        }).modal('show');
    });

    $("#DelCalendar").click(function () {
        var radioVal = $('input[name=radioCalendar]:checked').val();
        if (radioVal == null) {
            $('#EmptyModalCalendar').modal({
                closable: false,
                onDeny: function () {
                    return true;
                }
            }).modal('show');
        }
        else {
            $('#DelModalCalendar').modal({
                closable: false,
                onDeny: function () {
                    return true;
                },
                onApprove: function initAddPopup(modal) {
                    $.ajax({
                        type: "POST",
                        url: "/Calendar/Del",
                        data: { ID: $('input[name=radioCalendar]:checked').val() },
                        success: function (data) {
                            window.location.reload("/Calendar");
                        },
                        failure: function (errMsg) {

                        }
                    }).done(function () {
                        window.location.reload();
                    }).fail(function (jqXHR, textStatus) {
                        alert("Request failed: " + textStatus);
                    });
                }
            }).modal('show');
        }
    });

});
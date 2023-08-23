

function PostDelete(id, name, mail, subject, date, message) {
    var k = {
        Id: id,
        Name: name,
        Message: message,
        Mail: mail,
        Subject: subject,
        Process: false,
        Deleted: true,
        Date: date
    };

    postData("Contact/SendMessage", k, (response) => {
        getMessages();
    });
}


function PostArchive(id, name, mail, subject, date, message) {
    var k = {
        Id: id,
        Name: name,
        Message: message,
        Mail: mail,
        Subject: subject,
        Process: false,
        Archive: true,
        Date: date
    };

    postData("Contact/SendMessage", k, (response) => {
        getMessages();
    });
}


function PostSpam(id, name, mail, subject, date, message) {
    var k = {
        Id: id,
        Name: name,
        Message: message,
        Mail: mail,
        Subject: subject,
        Process: false,
        Spam: true,
        Date: date
    };

    postData("Contact/SendMessage", k, (response) => {
        getMessages();
    });
}


function PostImportant(id, name, mail, subject, date, message) {
    var k = {
        Id: id,
        Name: name,
        Message: message,
        Mail: mail,
        Subject: subject,
        Process: false,
        Important: true,
        Date: date
    };

    postData("Contact/SendMessage", k, (response) => {
        getMessages();
    });
}



function getMessages() {
    fetchData("Contact/ComeIn", function (response) {

        console.log("messages", response)
        var c = $("#cbody");
        c.empty();

        $.each(response, function (index, res) {
            var k = `            <tr>
                                                                        <td>
                                                                            <div class="icheck-primary">
                                                                                        <input type="checkbox" value="${res.process}" id="check15">
                                                                                <label for="check15"></label>
                                                                            </div>
                                                                        </td>
                                                                        <td class="mailbox-star"><a href="#"><i class="fas fa-star text-warning"></i></a></td>
                                                                        <td class="mailbox-name"><a href="/Admin/Contact/ReadMessage/${res.id}">${res.name}</a></td>
                                                                        <td class="mailbox-subject">
                                                                                            <b>Konu: ${res.subject}</b> <br/> <br/> <p> <p>${res.message}</p>
                                                                        </td>
                                                                        <td>
                                                                                            <i type="button"
                                                         onClick="PostDelete('${res.id}',
                                                                            '${res.name}',
                                                                            '${res.mail}',
                                                                            '${res.subject}',
                                                                            '${res.message}',
                                                                            '${res.date}')"
                                                                            class="far fa-trash-alt"></i>
                                                                                            <i type="button"
                                                         onClick="PostArchive('${res.id}',
                                                                                    '${res.name}',
                                                                                    '${res.mail}',
                                                                                    '${res.subject}',
                                                                                    '${res.message}',
                                                                                    '${res.date}'
                                                                                    )"
                                                                                    class="far fa-file-alt mx-2"></i>
                                                                                            <i type="button"
                                                        onClick="PostSpam('${res.id}',
                                                                          '${res.name}',
                                                                          '${res.mail}',
                                                                          '${res.subject}',
                                                                          '${res.message}',
                                                                          '${res.date}')"
                                                                          class="fas fa-filter"></i>
                                                                                                    <i type="button"
                                                        onClick="PostImportant('${res.id}',
                                                                               '${res.name}',
                                                                               '${res.mail}',
                                                                               '${res.subject}',
                                                                               '${res.message}',
                                                                               '${res.date}')"
                                                                               class="far fa-circle text-danger ml-4"></i>
                                                                        </td>
                                                                        <td class="mailbox-attachment"><i class="fas fa-paperclip"></i></td>
                                                                                <td class="mailbox-date">${res.date}</td>
                                                                    </tr>
                                            `

            c.append(k);
        })

    })
}

$(document).ready(function () {
    getMessages();

})



$(function () {

    //Enable check and uncheck all functionality

    $('.checkbox-toggle').click(function () {

        var clicks = $(this).data('clicks')

        if (clicks) {

            //Uncheck all checkboxes

            $('.mailbox-messages input[type=\'checkbox\']').prop('checked', false)

            $('.checkbox-toggle .far.fa-check-square').removeClass('fa-check-square').addClass('fa-square')

        } else {

            //Check all checkboxes

            $('.mailbox-messages input[type=\'checkbox\']').prop('checked', true)

            $('.checkbox-toggle .far.fa-square').removeClass('fa-square').addClass('fa-check-square')

        }

        $(this).data('clicks', !clicks)

    })



    //Handle starring for glyphicon and font awesome

    $('.mailbox-star').click(function (e) {

        e.preventDefault()

        //detect type

        var $this = $(this).find('a > i')

        var glyph = $this.hasClass('glyphicon')

        var fa = $this.hasClass('fa')



        //Switch states

        if (glyph) {

            $this.toggleClass('glyphicon-star')

            $this.toggleClass('glyphicon-star-empty')

        }



        if (fa) {

            $this.toggleClass('fa-star')

            $this.toggleClass('fa-star-o')

        }

    })

})


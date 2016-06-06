this.addEventListener("load", init);

function init()
{
    GetAllSesies();
}

function GetAllSesies()
{
    jQuery.support.cors = true;
    $.ajax({
        url: "http://localhost1729/api/sessie",
        type: 'GET',
        dataType: "json",
        succes: function (data) {
            var strResult = "<div class='col-xs-12' id='tabel'><table class='table-bordered'><tr><th>Sessienaam</th></tr>"
     
            for (var x = 0; x < data.lenth; x++){
                strResult+= "<tr><td><a href=# " + data.Naam + "</a></td></tr>"
            }
            strResult += "</table><>div>"
            $("#tabel").html(strResult);
        }
    })
}
var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_loadTran').DataTable({
        "ajax": {
            "url": "/api/dailytransaction",
            "type": "GET",
            "datatype": "json"
        },
        // HERE YOU HAVE TO TYPE THE DATABASE FIELD NAMES CORRESPONDING TO 
        "columns": [
            //{ "data": "transactionDate", "type": "date string" ,  "width": "25%" },
            {
                "data": "transactionDate",
                "render": function (data) {
                    var date = new Date(data);
                    //var month = date.getMonth(); //+ 1;
                    var mn = ["Jan", "Feb", "Mar", "Apr","May","Jun", "Jul","Aug","Sep", "Oct" , "Nov" , "Dec"];
                    var month = mn[date.getMonth()];

                    var hr = date.getHours();
                    if (hr.toString().length == 1) { hr =  "0" + hr };
                    var min = date.getMinutes();
                    if (min.toString().length == 1) { min = "0" + min };
                    var sec = date.getSeconds();
                    if (sec.toString().length == 1) { sec = "0" + sec };
                   
                    tm = hr + ":" + min  + ":" +  sec

                    //return (month.toString().length > 1 ? month : "0" + month) + "/" + date.getDate() + "/" + date.getFullYear() ;
                    return date.getDate()  + "-" +  month + "-" +  date.getFullYear() + " " + tm  ;
                }, "width": "25%"
            },
            { "data": "transactionName", "width": "25%" },
            { "data": "transactionDetails", "width": "25%" },
            { "data": "transactionInAmt", "width": "25%" },
            { "data": "transactionOutAmt", "width": "25%" },
            { "data": "transactionBalance", "width": "25%" },
            {
                "data": "transactionId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/DailyTransactionList/Edit?id=${data}" class='btn btn-success btn-sm text-white' style='cursor:pointer; width:55px;'>
                            Edit
                        </a>
                        </div>`;
                }, "width": "15%"
            },
            {
                "data": "transactionId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a class='btn btn-danger btn-sm text-white' style='cursor:pointer; width:55px;'
                            onclick=Delete('/api/dailytransaction?id='+${data})>
                            Delete
                        </a>
                        </div>`;
                }, "width": "15%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, cant be recovered.",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
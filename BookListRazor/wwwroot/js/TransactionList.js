var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/transaction",
            "type": "GET",
            "datatype": "json"
        },
        // HERE YOU HAVE TO TYPE THE DATABASE FIELD NAMES CORRESPONDING TO 
        "columns": [
            {
                "data": "transactionDate",
                "render": function (data) {
                    var date = new Date(data);
                    //var month = date.getMonth(); //+ 1;
                    var mn = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
                    var month = mn[date.getMonth()];

                    var hr = date.getHours();
                    if (hr.toString().length == 1) { hr = "0" + hr };
                    var min = date.getMinutes();
                    if (min.toString().length == 1) { min = "0" + min };
                    var sec = date.getSeconds();
                    if (sec.toString().length == 1) { sec = "0" + sec };

                    tm = hr + ":" + min + ":" + sec

                    //return (month.toString().length > 1 ? month : "0" + month) + "/" + date.getDate() + "/" + date.getFullYear() ;
                    return date.getDate() + "-" + month + "-" + date.getFullYear() + " " + tm;
                }, "width": "10%"
            },
            { "data": "transactionName", "width": "10%" },
            { "data": "transactionDesc", "width": "10%" },
            { "data": "transactionInvoiceRef", "width": "10%" },
            { "data": "productId", "width": "10%" },
            { "data": "productName", "width": "10%" },
            { "data": "inventoryInUnit", "width": "10%" },
            { "data": "inventoryOutUnit", "width": "10%" },
            { "data": "inventoryBalUnit", "width": "10%" },
            { "data": "productCostPricePU", "width": "10%" },
            { "data": "productSellingPricePU", "width": "10%" },
            { "data": "invBalCostPriceTotal", "width": "10%" }, 
            {
                "data": "transactionId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/TransactionList/Edit?id=${data}" class='btn btn-success btn-sm text-white' style='cursor:pointer; width:55px;'>
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
                            onclick=Delete('/api/transaction?id='+${data})>
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
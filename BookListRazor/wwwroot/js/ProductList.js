var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/product",
            "type": "GET",
            "datatype": "json"
        },
        // HERE YOU HAVE TO TYPE THE DATABASE FIELD NAMES CORRESPONDING TO 
        "columns": [
            { "data": "productName", "width": "18%" },
            { "data": "productDesc", "width": "18%" },
            { "data": "vendorId", "width": "12%" },
            { "data": "vendorName", "width": "18%" },
            { "data": "productCost", "width": "14%" },
            { "data": "productMargin", "width": "13%" },
            { "data": "productSellingPrice", "width": "16%" },
            {
                "data": "productId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/ProductList/Edit?id=${data}" class='btn btn-success btn-sm text-white' style='cursor:pointer; width:55px;'>
                            Edit
                        </a>
                        </div>`;
                }, "width": "15%"
            },
            {
                "data": "productId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a class='btn btn-danger btn-sm text-white' style='cursor:pointer; width:55px;'
                            onclick=Delete('/api/product?id='+${data})>
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
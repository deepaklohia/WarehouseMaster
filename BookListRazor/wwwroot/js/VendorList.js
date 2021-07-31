var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/vendor",
            "type": "GET",
            "datatype": "json"
        },
        // HERE YOU HAVE TO TYPE THE DATABASE FIELD NAMES CORRESPONDING TO 
        "columns": [
            { "data": "vendorName", "width": "25%" },
            { "data": "vendorAddress", "width": "25%" },
            { "data": "vendorPhone", "width": "25%" },
            { "data": "vendorEmail", "width": "25%" },
            {
                "data": "vendorId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/VendorList/Edit?id=${data}" class='btn btn-success btn-sm text-white' style='cursor:pointer; width:55px;'>
                            Edit
                        </a>
                        </div>`;
                }, "width": "15%"
            },
            {
                "data": "vendorId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a class='btn btn-danger btn-sm text-white' style='cursor:pointer; width:55px;'
                            onclick=Delete('/api/vendor?id='+${data})>
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
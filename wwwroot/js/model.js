import { httpGet, httpDelete } from '/js/api.js';

export async function getCustomers() {
    $('#btnExport').hide();
    var response = await httpGet('api/api/get', null);
    if (response) {
        var output = '';
        $.each(response, function (index, customer) {
            output += '<tr>';
            output += '<td>' + customer.name + '</td>';
            output += '<td>' + customer.emailID + '</td>';
            output += '<td>' + customer.phone + '</td>';
            output += '<td>' + customer.address + '</td>';
            output += '<td>' + customer.productName + '</td>';
            output += '<td>' + customer.model + '</td>';
            output += '<td>' + customer.purchasedFrom + '</td>';
            output += '<td>' + customer.invoiceURL + '</td>';
            output += '<td>' + customer.ssurl + '</td>';
            output += '<td>' + customer.purchaseDate + '</td>';
            output += '<td>' + customer.createdOn + '</td>';
            output += '<td><button class="delete-btn" data-id="' + customer.id + '">Delete</button></td>';
            output += '</tr>';
        });
        $("#userTableBody").html(output);
        $('#btnExport').show();
        $("#overlay").fadeOut();
        $('#dataTable').DataTable();
    } else {

    }
}

// Asynchronously deletes a customer using their ID via an API request and handles success or error alerts.
// using for delete data
export async function deleteCustomer(id) {
    try {
        await httpDelete('api/api/delete/' + id);
        alert('Customer deleted successfully!');
        location.reload();
    } catch (error) {
        console.error('Error deleting customer:', error);
        alert('Error deleting customer. Please try again.');
    }
}


$(document).ready(function () {
    getCustomers();

    $(document).on('click', '.delete-btn', function () {
        var customerId = $(this).data('id');
        deleteCustomer(customerId);
    });
});

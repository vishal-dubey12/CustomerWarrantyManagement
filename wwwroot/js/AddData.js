import { httpPost } from '/js/api.js';

$(document).ready(function () {
    $('#addCustomerForm').submit(function (e) {
        e.preventDefault();

        var formData = {
            name: $('#name').val(),
            emailID: $('#email').val(),
            phone: $('#phone').val(),
            address: $('#address').val(),
            productName: $('#productName').val(),
            model: $('#model').val(),
            purchasedFrom: $('#purchasedFrom').val(),
            invoiceURL: $('#invoiceURL').val(),
            ssurl: $('#ssurl').val(),
            purchaseDate: $('#purchaseDate').val()
        };

        addCustomer(formData);
    });

    // Asynchronously adds a customer using provided data via an API request and handles success or error alerts.
    async function addCustomer(data) {
        try {
            await httpPost('/api/api/add', data);
            alert('Customer added successfully!');
        } catch (error) {
            console.error('Error adding customer:', error);
            alert('Error adding customer. Please try again.');
        }
    }
});

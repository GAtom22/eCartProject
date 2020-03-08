
var uri = 'api/ProductsAPI';
var CartUri = 'api/CartItemsAPI';


    $(document).ready(function () {
        // Send an AJAX request
        $.getJSON(uri)
            .done(function (data) { 
                // On success, 'data' contains a list of products.
                $.each(data.results, function (key, item) {
                    // Add a list item for the product.
                    $('<li>', { text: formatItem(item) }).appendTo($('#products'));
                    
                });
            });

});

    function formatItem(item) {
      return item.ProductID + " - " + item.ProductName + ': $' + item.UnitPrice;
  }

    function find() {
      var id = $('#prodId').val();
    $.getJSON(uri + '/' + id)
          .done(function (data) {
        $('#product').text(formatItem(data));
  })
          .fail(function (jqXHR, textStatus, err) {
        $('#product').text('Error: ' + err);
  });
}


function addToCart() {
    sessionStorage["ItemsNum"] = Number(sessionStorage["ItemsNum"]) + 1;

    //Check if item already exist in cartItems
    var id = $('#prodId').val();
    $.getJSON(CartUri + '/' + id)
        .done(function (data) {
            data.Quantity += 1;
            updateCartItem(data);
        })
        .fail(function (jqXHR, textStatus, err) {
            var item = {
                ItemId: sessionStorage["ItemsNum"].toString(),
                CartId: sessionStorage["CartId"].toString(),
                Quantity: 1,
                DateCreated: new Date(),
                ProductId: id
            }
            $.post(CartUri + '/' + item)
                .done(() => {
                    console.log("item added")
                })
                .fail(() => {
                    sessionStorage["ItemsNum"] = Number(sessionStorage["ItemsNum"]) - 1;
                    console.log("failed")
                })
             });
}

function updateCartItem(item) {
    $.ajax({
        url: CartUri + "/" + item,
        type: 'PUT',
        success: function (result) {
            console.log("updated!")
        },
        fail: function (err) {
            console.error(err);
        }
    });
}
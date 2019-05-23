var index = namespace("Index");

index.changeBrand = function () {
    var qmake = index.brand.val();
    var qtype = index.qtype.val();

    if (qmake == "-1") {
        index.model.find('option')
            .remove()
            .end();

        index.model.prop('disabled', 'disabled');

        return;
    }

    $.ajax({
        type: "GET",
        url: "/api/inventoryapi/list/inventory/models?makeId=" + qmake + "&typeId=" + qtype,
        success: index.changeBrandSuccess
    });
};

index.changeBrandSuccess = function (data) {
    index.model.find('option')
        .remove()
        .end();

    $.each(data, function (ind, option) {
        index.model.append($('<option>', { value: option.id })
            .text(option.name));
    });

    index.model.prop('disabled', false);
};

index.changeModel = function () {
    var qmodel = index.model.val();

    if (qmodel == "-1") {
        index.deck.find('option')
            .remove()
            .end();

        index.deck.prop('disabled', 'disabled');
        return;
    }

    $.ajax({
        type: "GET",
        url: "/api/inventoryapi/list/inventory/model/options?modelId=" + qmodel,
        success: index.changeModelSuccess
    });
};

index.changeModelSuccess = function (data) {
    index.deck.find('option')
        .remove()
        .end();

    $.each(data, function (ind, option) {
        index.deck.append($('<option>', { value: option.id })
            .text(option.name));
    });

    index.deck.prop('disabled', false);
};

index.initialize = function () {
    index.qtype = $('#QInventoryType');
    index.brand = $('#QInventoryMake');
    index.model = $('#QInventoryModel');
    index.deck = $('#QDeck');
    index.zip = $('#ZipCode');
    index.radius = $('#QZipCodeRadius');

    index.qtype.val("1");
    $("#QInventoryMake").change(index.changeBrand);
    $("#QInventoryModel").change(index.changeModel);
};

$(function () {
    index.initialize();
});
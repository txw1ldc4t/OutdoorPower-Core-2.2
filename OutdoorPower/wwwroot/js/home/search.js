var page = namespace("Search");

page.changeBrand = function () {
    var qmake = page.brand.val();
    var qtype = page.qtype.val();

    if (qmake == "-1") {
        page.model.find('option')
            .remove()
            .end();

        page.model.prop('disabled', 'disabled');

        return;
    }

    $.ajax({
        type: "GET",
        url: document.location.origin + "/api/inventoryapi/list/inventory/models?makeId=" + qmake + "&typeId=" + qtype,
        success: page.changeBrandSuccess
    });
};

page.changeBrandSuccess = function (data) {
    page.model.find('option')
        .remove()
        .end();

    $.each(data, function (ind, option) {
        page.model.append($('<option>', { value: option.id })
            .text(option.name));
    });

    page.model.prop('disabled', false);
};

page.changeModel = function () {
    var qmodel = page.model.val();

    if (qmodel == "-1") {
        page.deck.find('option')
            .remove()
            .end();

        page.deck.prop('disabled', 'disabled');
        return;
    }

    $.ajax({
        type: "GET",
        url: document.location.origin + "/api/inventoryapi/list/inventory/model/options?modelId=" + qmodel,
        success: page.changeModelSuccess
    });
};

page.changeModelSuccess = function (data) {
    page.deck.find('option')
        .remove()
        .end();

    $.each(data, function (ind, option) {
        page.deck.append($('<option>', { value: option.id })
            .text(option.name));
    });

    page.deck.prop('disabled', false);
};

page.initialize = function () {
    page.qtype = $('#QInventoryType');
    page.brand = $('#QInventoryMake');
    page.model = $('#QInventoryModel');
    page.deck = $('#QDeck');
    page.engineBrand = $('#EngineBrand');
    page.engineHorsePower = $('#EngineHorsePower');
    page.zip = $('#ZipCode');
    page.radius = $('#QZipCodeRadius');

    $("#QInventoryMake").change(page.changeBrand);
    $("#QInventoryModel").change(page.changeModel);
    page.engineBrand.change(page.changeEngineBrand);
};

page.changeEngineBrand = function () {
    var qbrand = page.engineBrand.val();

    if (qbrand == "") {
        page.engineHorsePower.find('option')
            .remove()
            .end();

        page.engineHorsePower.prop('disabled', 'disabled');

        return;
    }

    $.ajax({
        type: "GET",
        url: document.location.origin + "/api/inventoryapi/list/engine/horsepower?engineBrand=" + qbrand,
        success: page.changeEngineBrandSuccess
    });
};

page.changeEngineBrandSuccess = function (data) {
    page.engineHorsePower.find('option')
        .remove()
        .end();

    page.engineHorsePower.append('<option>Select</option>');

    $.each(data, function (ind, option) {
        page.engineHorsePower.append($('<option>', { value: option })
            .text(option));
    });

    page.engineHorsePower.prop('disabled', false);
};

page.changePage = function(page){
    $('#PageNum').val(page);
    $('#SearchForm').submit();
}

$(function () {
    page.initialize();
});
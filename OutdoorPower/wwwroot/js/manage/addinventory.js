var page = namespace("AddInventory");

page.changeBrand = function () {
    var qmake = page.brand.val();
    var qtype = page.qtype.val();

    if (qmake == "-1" || qmake == "-2") {
        page.model.find('option')
            .remove()
            .end();

        page.deck.find('option')
            .remove()
            .end();

        page.model.prop('disabled', 'disabled');
        page.deck.prop('disabled', 'disabled');

        if (qmake == "-2") {
            page.showBrandOther();
            page.showModelOther();
            page.showDeckOther();

            page.divModel.addClass('collapse');
            page.divModelOptionOther.addClass('collapse');
        };

        return;
    }

    page.divModel.removeClass('collapse');
    page.divModelOption.removeClass('collapse');

    page.rowOther.addClass('collapse');
    page.divMakeOther.addClass('collapse');
    page.divModelOther.addClass('collapse');
    page.divModelOptionOther.addClass('collapse');

    page.brandOther.val('');
    page.modelOther.val('');
    page.modelOptionOther.val('');

    $.ajax({
        type: "GET",
        url: "/api/inventoryapi/list/inventory/models?makeId=" + qmake + "&typeId=" + qtype,
        success: page.changeBrandSuccess
    });
};

page.changeBrandSuccess = function (data) {
    page.model.find('option')
        .remove()
        .end();

    page.model.append('<option>Select</option>');

    $.each(data, function (ind, option) {
        page.model.append($('<option>', { value: option.id })
            .text(option.name));
    });

    page.model.append('<option value="-2">Other</option>');

    page.model.prop('disabled', false);
};

page.changeModel = function () {
    var qmodel = page.model.val();

    if (qmodel == "-1" || qmodel == "-2") {
        page.deck.find('option')
            .remove()
            .end();

        page.deck.prop('disabled', 'disabled');

        if (qmodel == "-2") {
            page.showModelOther();
            page.showDeckOther();

            page.divModelOption.addClass('collapse');
            page.divMakeOther.addClass('collapse');
        };

        return;
    }

    page.rowOther.addClass('collapse');
    page.divModelOption.removeClass('collapse');

    page.divModelOther.addClass('collapse');
    page.divModelOptionOther.addClass('collapse');

    page.modelOther.val('');
    page.modelOptionOther.val('');

    $.ajax({
        type: "GET",
        url: "/api/inventoryapi/list/inventory/model/options?modelId=" + qmodel,
        success: page.changeModelSuccess
    });
};

page.changeModelSuccess = function (data) {
    page.deck.find('option')
        .remove()
        .end();

    page.deck.append('<option>Select</option>');

    $.each(data, function (ind, option) {
        page.deck.append($('<option>', { value: option.id })
            .text(option.name));
    });

    page.deck.append('<option value="-2">Other</option>');
    page.deck.prop('disabled', false);
};

page.changeDeck = function () {
    var qdeck = page.deck.val();

    if (qdeck == "-1" || qdeck == "-2") {
        if (qdeck == "-2") {
            page.showDeckOther();
            page.divMakeOther.addClass('collapse');
            page.divModelOther.addClass('collapse');
        };

        return;
    }

    page.rowOther.addClass('collapse');
    page.divModelOptionOther.addClass('collapse');
    page.modelOptionOther.val('');
}

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
        url: "/api/inventoryapi/list/engine/horsepower?engineBrand=" + qbrand,
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

page.deleteImageSuccess = function (data) {
    var imageDiv = $('#ImageDiv_' + data);
    imageDiv.remove();
};

page.deleteImage = function (imageId) {
    $.ajax({
        type: 'DELETE',
        url: '/manage/imagedelete?imageId=' + imageId,
        success: page.deleteImageSuccess
    });
};

page.showBrandOther = function () {
    page.rowOther.removeClass('collapse');
    page.divMakeOther.removeClass('collapse');
};

page.showModelOther = function () {
    page.rowOther.removeClass('collapse');
    page.divModelOther.removeClass('collapse');
};

page.showDeckOther = function () {
    page.rowOther.removeClass('collapse');
    page.divModelOptionOther.removeClass('collapse');
};

page.initialize = function () {
    page.qtype = $('#QInventoryTypeId');
    page.brand = $('#QInventoryMakeId');
    page.model = $('#QInventoryModelId');
    page.deck = $('#QInventoryModelOptionId');
    page.engineBrand = $('#EngineBrand');
    page.engineHorsePower = $('#EngineHorsePower');

    page.brandOther = $('#QInventoryMakeOther');
    page.modelOther = $('#QInventoryModelOther');
    page.modelOptionOther = $('#QInventoryModelOptionOther');

    page.divModel = $('#div-model');
    page.divModelOption = $('#div-modeloption');

    page.rowOther = $('#row-other');
    page.divMakeOther = $('#div-make-other');
    page.divModelOther = $('#div-model-other');
    page.divModelOptionOther = $('#div-modeloption-other');

    page.qtype.val("1");
    page.brand.change(page.changeBrand);
    page.model.change(page.changeModel);
    page.deck.change(page.changeDeck);
    page.engineBrand.change(page.changeEngineBrand);

    if (page.brandOther.val() != '') {
        page.showBrandOther();
        page.showModelOther();
        page.showDeckOther();

        page.divModel.addClass('collapse');
        page.divModelOption.addClass('collapse');
    } else if (page.modelOther.val() != '') {
        page.showModelOther();
        page.showDeckOther();

        page.divMakeOther.addClass('collapse');
        page.divModelOption.addClass('collapse');
    } else if (page.modelOptionOther.val() != '') {
        page.showDeckOther();

        page.divMakeOther.addClass('collapse');
        page.divModelOther.addClass('collapse');
    }
};

$(function () {
    page.initialize();
});
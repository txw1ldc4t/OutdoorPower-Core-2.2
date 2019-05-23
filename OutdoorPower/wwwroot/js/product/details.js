var page = namespace("Details");

page.initialize = function () {
    $("#home-slider-canvas").owlCarousel({
        items: 1,
        navigation: true,
        navigationText: ["prev", "next"],
        pagination: true,
        paginationNumbers: true,
        singleItem: true,
        mouseDrag: false,
        touchDrag: false,
        lazyLoad: true,

        if($(".financing_calculator").length) {
        // Financing Calculator
        $(document).on("click", '.financing_calculator .calculate', function () {
            var calculator = $(this).closest(".financing_calculator");

            var cost = calculator.find(".cost").val();
            var down_payment = calculator.find(".down_payment").val();
            var interest = calculator.find(".interest").val();
            var loan_years = calculator.find(".loan_years").val();
            var frequency = calculator.find(".frequency").val();

            if (!cost || !down_payment || !interest || !loan_years || isNaN(cost) || isNaN(down_payment) || isNaN(interest) || isNaN(loan_years)) {
                if (!cost || isNaN(cost)) {
                    calculator.find(".cost").addClass("error");
                } else {
                    calculator.find(".cost").removeClass("error");
                }

                if (!down_payment || isNaN(down_payment)) {
                    calculator.find(".down_payment").addClass("error");
                } else {
                    calculator.find(".down_payment").removeClass("error");
                }

                if (!interest || isNaN(interest)) {
                    calculator.find(".interest").addClass("error");
                } else {
                    calculator.find(".interest").removeClass("error");
                }

                if (!loan_years || isNaN(loan_years)) {
                    calculator.find(".loan_years").addClass("error");
                } else {
                    calculator.find(".loan_years").removeClass("error");
                }

                return;
            }

            calculator.find("input").removeClass("error");

            switch (frequency) {
                case "0":
                    frequency_rate = 26;
                    break;
                case "1":
                    frequency_rate = 52;
                    break;
                case "2":
                    frequency_rate = 12;
                    break;
            }

            interest_rate = (interest) / 100;
            rate = interest_rate / frequency_rate;
            payments = loan_years * frequency_rate;
            difference = cost - down_payment;

            payment = Math.floor((difference * rate) / (1 - Math.pow((1 + rate), (-1 * payments))) * 100) / 100;

            calculator.find(".payments").text(payments);
            calculator.find(".payment_amount").text("$" + payment);
        });
    });
};

$(function () {
    page.initialize();
});

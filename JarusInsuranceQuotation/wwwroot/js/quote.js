/// <reference path="../lib/jquery/dist/jquery.js" />

$(document).ready(function () {

    var addInsuredpersonIds = [];
    findPeople();
    
    $(".btn-search").on("click", function (e) {
        findPeople();
    });

    $(document).on("click", ".btn-delete", function (e) {
        var personid = $(this).attr("id");
        addInsuredpersonIds = jQuery.grep(addInsuredpersonIds, function (value) {
            return value != personid;
        });
        loadAdditionalInsurers(addInsuredpersonIds);
    });

    $(document).on("click", ".btn-select", function (e) {
        var personid = $(this).attr("id");
        if (addInsuredpersonIds.indexOf(personid) !== -1)
            return;
        addInsuredpersonIds.push(personid)
        loadAdditionalInsurers(addInsuredpersonIds);
    });

});

var findPeople = function () {
    var url = "FindPeople?firstname=" + $("#searchFirstName").val() + "&lastname=" + $("#searchLastName").val();
    $("#_SearchResults").load(url);
};

var loadAdditionalInsurers = function (addInsuredpersonIds) {
    var url = "GetAdditionalInsurers?personIds=" + addInsuredpersonIds.join(",");
    $("#_AdditionalInsuredResults").load(url);
}
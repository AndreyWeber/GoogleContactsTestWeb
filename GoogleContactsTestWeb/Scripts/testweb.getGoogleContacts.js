//'use strict';

//angular.module('webMinutesApp.services')
//    .factory('GoogleContactsService', ['AccountModel', function (accountModel) {
//        return {
//            get: function (callback) {
//                var token = accountModel.googleApiToken;
//                $.getJSON('https://www.google.com/m8/feeds/contacts/default/full/?access_token=' +
//                     token + "&alt=json", function (data) {
//                         callback(data)
//                     });
//            }
//        };
//    }]);

//var console = window.console || { log: function () { 'use strict'; } };
//var testweb = window.testweb || {};

//(function ($) {
//    'use strict';

//    var module = {};

//    var form = $('#survey-details-form');

//    $(document).ready(function () {
//        // Set sortable functionality for questions lists
//        module.setQuestionsListsSortable();

//        // Set form onSubmit handler to fill SelectedQuestions view model field
//        form.submit(module.setSelectedQuestionsList);
//    });

//    module.setQuestionsListsSortable = function () {
//        $("#surveyQuestionsList, #availableQuestionsList").sortable({
//            connectWith: ".questions-connected-sortable"
//        }).disableSelection();
//    };

//    module.setSelectedQuestionsList = function () {
//        var questionsIdsList = [];
//        form.find('#surveyQuestionsList > li').each(function () {
//            questionsIdsList.push($(this).attr('id'));
//        });

//        $('#SelectedQuestionsIds').val(questionsIdsList.join());
//    };

//    testweb.getGoogleContacts = module;
//}(jQuery));
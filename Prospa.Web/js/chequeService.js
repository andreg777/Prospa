chequeApp.factory("chequeService", function ($http) {

    var service = {

        viewModel: {
            showInput: true,
            name: '',
            amount: null,
            date:new Date(),
            wordOutput: '',
            error: '',            
        },

        getViewModel: function () {
            return service.viewModel;
        },

        convertNumberToWords: function () {

            var url = 'http://localhost:63348/api/ChequeApi/ConvertNumberToWords';

            var vm = {
                name: service.viewModel.name,
                amount: service.viewModel.amount,
                date: service.viewModel.date
            };

            $http({ method: "POST", url: url, data: vm })
                .success(this.convertNumberToWordsSuccess.bind(this))
                .error(this.convertNumberToWordsError.bind(this));
        },

        convertNumberToWordsSuccess: function (chequeModel) {            
            service.viewModel.wordOutput = chequeModel.wordOutput;
            service.viewModel.error = '';
            service.viewModel.showInput = false;
        },

        convertNumberToWordsError: function (serviceResult) {
            service.viewModel.error = 'An error occurred while converting a number to a word: ' + JSON.stringify(serviceResult);
        }
    }

    return service;
});
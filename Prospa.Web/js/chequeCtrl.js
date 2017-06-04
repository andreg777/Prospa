chequeApp.controller("chequeCtrl", function ($scope, chequeService) {

    $scope.viewModel = chequeService.getViewModel();
    $scope.convertNumberToWords = chequeService.convertNumberToWords.bind(chequeService);

});

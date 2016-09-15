
var myApp = angular
           .module("myModule", [])
           .controller("myController", function ($scope, $http) {
               $http.get('ThemesService.asmx/GetFreeTheme')
                    .then(function (response) {
                        $scope.themes = response.data;
                    });
            })
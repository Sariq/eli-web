(function () {

  function routes($routeProvider) {
      $routeProvider
      .when('/about', {
        templateUrl: 'views/about.html',
        controller: ''


      })
      .when('/main', {
        templateUrl: 'main/views/main.html',
        controller: 'MainCtrl',
        controllerAs: 'main'

      })

  }
  angular.module('eliApp')
    .config(['$routeProvider',routes])

}());

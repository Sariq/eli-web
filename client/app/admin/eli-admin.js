'use strict';


  angular.module('eli.admin', [
  'ngResource',
  'ui.router'
])
  .config(function ($stateProvider, $urlRouterProvider,$resourceProvider) {
    //delete $httpProvider.defaults.headers.common['X-Requested-With'];
    

    $stateProvider
      .state('dashboard', {
        url: '/dashboard',
        templateUrl: 'partials/dashboard.html',
      
      }) 
        .state('logIn', {
         url: '/',
        templateUrl: 'auth/views/logIn/logIn.html',
       
        controllerAs: 'logIn'

      })
   
          $urlRouterProvider.otherwise('/');
  })





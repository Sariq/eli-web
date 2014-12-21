
'use strict';


  angular.module('tutorialWebApp', [
  'ui.router'
])
  .config(function ($stateProvider, $urlRouterProvider) {
    //delete $httpProvider.defaults.headers.common['X-Requested-With'];
    

    $stateProvider
      .state('dashboard', {
        url: '/',
        templateUrl: 'partials/dashboard.html',
      
      }) 
   
          $urlRouterProvider.otherwise('/');
  })





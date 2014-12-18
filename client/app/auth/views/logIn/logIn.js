(function () {
  function LogInCtrl(AuthService,$scope) {
    var self = this;
    self.test=''
    self.user = AuthService.create();

     $scope.$on('authLoaded', function() {
      alert()
  /*  $scope.isExpert($scope.main.serieId);
    $scope.isMember($scope.main.serieId);*/
  });
 



    self.logIn=function(){

    self.user.$save(function(d) {
              self.user =d;
              console.log(self.user)
               //$scope.$broadcast("authLoaded");

              },function(d) {
              self.error =d;
              console.log(self.error)
               self.user.password=''
              });
      
    


/*    Auth.login({
      username: $scope.main.credentials.email,
      password: $scope.main.credentials.password
    }).success(function(data) {
      if (data.error) {
        toastr.error(data.error);
      } else {
        toastr.success("You are signed in!");
        $scope.$broadcast("authLoaded");
        $scope.main.credentials = {};
        Popup.close();
      }
    });*/
  

//POST   
/*console.log(self.user)      
  self.user.$save(function(d) {
              self.w=d;
              console.log(self.w)
              });*/
//UPDATE
/*  self.user.$update(function(d) {
              self.w=d;
              console.log(self.w)
              });*/
//GET
//AuthService.get(1);

//DELETE
/*self.user.$remove({id: 1}, function(d) {
              self.w=d;
              console.log(self.w)
              });*/
    }


  }

  angular.module('eliApp')
    .controller('LogInCtrl', ['AuthService','$scope',LogInCtrl]);
}());

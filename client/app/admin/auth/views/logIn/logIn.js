(function () {
    function LogInCtrl(AuthService, $scope, $location, $rootScope, localStorageService) {
        var self = this;
        console.log("LogInCtrl")
        
        $scope.obj={}
        $scope.obj.user = AuthService.create();
        $scope.ob={};
        $scope.ob.navShow=false;
        /*     $scope.$on('authLoaded', function() {
              alert()
            $scope.isExpert($scope.main.serieId);
            $scope.isMember($scope.main.serieId);
          });*/
        $scope.$on('logOut', function() {
            $scope.ob.navShow=false;
            loadAuth();
      
            console.log( $scope.userInfo)


        });
    
 


        //if (localStorageService.isSupported) {
        //    console.log("yes");
        //}

        
        function submit(key, val) {
           // console.log(localStorageService.set(key, val));
            console.log(getItem(key));
        }

        function getItem(key) {
            return localStorageService.get(key);
        }
        submit('sariXXtestKey', 'sariXX2testvalue');
        function loadAuth() {



          
          //  $location.path('/logIn')
            //$scope.obj.user.$save(function(d) {
            //         $scope.obj.user =d;
            //        // console.log(self.user)
              
               
            //          $rootScope.$broadcast("authLoaded");

                
            //           $location.path('/logIn')

            //         },function(d) {
            //         $scope.error =d;
            //         console.log($scope.error)
            //          $scope.obj.user.password=''
            //         });
        }

        $scope.logIn = function () {


            AuthService.setUserInfo($scope.obj.user);
            console.log($scope.obj.user)
             $scope.obj.user.$save(function(d) {
              $scope.obj.user =d;
              console.log($scope.obj.user)
         
               AuthService.setUserInfo($scope.obj.user);
             
               $rootScope.$broadcast("authLoaded");
               $rootScope.nav.show = true;
                //console.log( AuthService.userInfo)
                $location.path('/dashboard')

             }, function (d) {
                 $scope.error = d;
                 console.log($scope.error.data._errorDescription)
                 swal({ title: $scope.error.data._errorDescription, text: "Please check your User Name and Password!", type: "warning", confirmButtonText: "Try Again" }, function (isConfirm) { if (isConfirm) { } });
              $scope.error =d;
             console.log($scope.error)
               //$scope.obj.user._password=''
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

loadAuth();
  }

  angular.module('eli.admin')
    .controller('LogInCtrl', ['AuthService', '$scope', '$location', '$rootScope', 'localStorageService', LogInCtrl]);
}());

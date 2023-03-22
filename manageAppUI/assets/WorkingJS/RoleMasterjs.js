

var app = angular.module("myapp", []);




app.service('AppService', function ($http) {
    //Get Record
    this.List = function () {
        return $http.get('/api/RoleMaster/GetList');
    };
    //Insert Record
	this.Input = function (obj) {
		return $http.post('/api/RoleMaster/ADDRole', obj);
    }

});

app.controller("appController", function ($scope, AppService, $http) {
    $scope.RoleId = 0;
    $scope.ShowDetail = false;
    $scope.RoleList = [];

    $scope.submissionCompleted = false;
 


    $scope.role = {
        RoleName: null,
        Desiganation: null,
        Mobile_Number: null,
        Eamil: null,
        Password: null,
        createBy: 1,
        ModifiedBy:2,
    };
    $scope.init = function () {
        $scope.submissionCompleted = false;
       
        $scope.role = {
            RoleName: null,
            Desiganation: null,
            Mobile_Number: null,
            Eamil: null,
            Password: null,
            CreatedBy: 1,
            ModifiedBy: 2,
        };
          //GetList
        AppService.List().then(function (response) {
            console.log("res", response);
                if(response.data.length > 0){
                $scope.ShowDetail = true;
                $scope.RoleList = response.data;
                console.log('UserList', $scope.RoleList);
            }
            else {
            }
            
        })
        console.log("rolename", $scope.role.RoleName);
    }
    $scope.RoleName = 'Angularjs';
    //Insert
    $scope.Input = function () {

        AppService.Input($scope.role).then(function (success) {

            $scope.ResData = success.data;
            
            alert($scope.ResData, success);
            console.log($scope.ResData);
                $scope.init();
            })
        $scope.init();
    }


    //insert
   $scope.inputFn = function (event) {
        var rName = $scope.role.RoleName;
       // var rName = event.target.value;
        angular.forEach($scope.RoleList, function (value, key) {
            if (rName == value['RoleName']) {
                $scope.role.RoleName = "";
                alert(" role name is duplicate. please change role name.");
            }
        })
    }

    //Update
    $scope.updatedata = function (role) {
        $scope.role = role;
    };
    $scope.updateRole = function () {
        $http({
            method: "PUT",
            url: "/api/RoleMaster/UpdateRole",
            data: $scope.role
        }).then(function (res) {
            $scope.init();
            console.log(res.data);
            $scope.RoleList = res;
            alert(res.data, $scope.RoleList);
                console.log("res", res);
            
     
        });
        
    };

          //delete
    $scope.DeleteEmp = function (RoleId) {
        console.log(RoleId);
        if (confirm("Do you really want to delete entry " + RoleId + "?\nConfirm with ok.")) {

            $http({
                method: "Delete",
                url: "/api/RoleMaster/RemoveCompany?RoleId=" + RoleId,
               
            }).then(function (res) {
                alert("Delete Successfully", res);
                $http.get('/api/RoleMaster/GetList').then(function (response) {
                  
                    $scope.init();
                    console.log(response);
                });
                });
        }
    }

    $scope.init();

});
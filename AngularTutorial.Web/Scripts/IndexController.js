angular.module('AngularTutorial', ["ui.ace"]).controller('IndexController', ["$scope", "$http", function ($scope, $http) {
    $scope.html = "";
    $scope.javaScript = "";
    $scope.title = "";
    $scope.instructions = "";
    $scope.startingHtml = "";
    $scope.solutionHtml = "";
    $scope.startingJavaScript = "";
    $scope.solutionJavaScript = "";
    $scope.frameWriteInstructions = [];

    $scope.run = function () {
        var doc = window.frames[0].document;
        doc.open();
        doc.write("<html><body>");
        doc.write($scope.html);
        doc.write("<script>");
        doc.write($scope.javaScript);
        doc.write("<\/script><\/body><\/html>");
        doc.close();
    };

    $scope.setStep = function (id) {
        $scope.loadStep(id);
    };

    $scope.loadStep = function (id) {
        $http.get("/Home/GetStep", { params: { id: id } })
        .success(function (data, status, headers, config) {
            $scope.title = data.Title;
            $scope.instructions = data.Instructions;
            $scope.html = $scope.startingHtml = data.StartingHtml;
            $scope.solutionHtml = data.SolutionHtml;
            $scope.javaScript = $scope.startingJavaScript = data.StartingJavaScript;
            $scope.solutionJavaScript = data.SolutionJavaScript;
            $scope.frameWriteInstructions = data.FrameWriteInstructions;
        })
        .error(function (data, status, headers, config) {
            alert("Error!");
        });
    };
}]);
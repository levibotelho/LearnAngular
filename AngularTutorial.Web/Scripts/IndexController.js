angular.module('AngularTutorial', ["ui.ace"]).controller('IndexController', ["$scope", "$http", "$sce", function ($scope, $http, $sce) {
    $scope.title = "";
    $scope.instructions = "";
    $scope.html = "";
    $scope.initialHtml = "";
    $scope.solutionHtml = "";
    $scope.javaScriptPages = [];
    $scope.headIncludes = undefined;
    $scope.scriptIncludes = undefined;

    $scope.parseJavaScriptPages = function (pages) {
        $scope.javaScriptPages.clear();
        for (var i = 0; i < pages.length; i++) {
            var page = pages[i];
            $scope.javaScriptPages.push({
                name: page.Name,
                javaScript: page.Initial,
                initialJavaScript: page.Initial,
                solutionJavaScript: page.Solution
            });
        }
    };

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
            $scope.instructions = $sce.trustAs("html", data.Instructions);
            $scope.html = $scope.initialHtml = data.Html.Initial;
            $scope.solutionHtml = data.Html.Solution;
            $scope.parseJavaScriptPages(data.JavaScript.Pages);
            $scope.headIncludes = data.headIncludes;
            $scope.scriptIncludes = data.scriptIncludes;
        })
        .error(function (data, status, headers, config) {
            alert("Error!");
        });
    };
}]);
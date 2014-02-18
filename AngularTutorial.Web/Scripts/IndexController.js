angular.module('AngularTutorial', ["ui.ace"]).controller('IndexController', ["$scope", "$http", "$sce", function ($scope, $http, $sce) {
    $scope.title = "";
    $scope.instructions = "";
    $scope.htmlDocuments = [];
    $scope.javaScriptDocuments = [];
    $scope.headIncludes = undefined;
    $scope.scriptIncludes = undefined;

    $scope.generateDocumentId = function(name) {
        return name != undefined  ? name.replace(".", "") : undefined;
    };

    $scope.parseHtmlDocuments = function(documents) {
        $scope.htmlDocuments.length = 0;
        for (var i = 0; i < documents.length; i++) {
            var document = documents[i];
            $scope.htmlDocuments.push({
                name: document.Name,
                id: $scope.generateDocumentId(document.Name),
                header: document.Header,
                html: document.Initial,
                initialhtml: document.Initial,
                solutionHtml: document.Solution,
                footer: document.Footer
            });
        }
    };

    $scope.parseJavaScriptDocuments = function (documents) {
        $scope.javaScriptDocuments.length = 0;
        for (var i = 0; i < documents.length; i++) {
            var document = documents[i];
            $scope.javaScriptDocuments.push({
                name: document.Name,
                id: $scope.generateDocumentId(document.Name),
                javaScript: document.Initial,
                initialJavaScript: document.Initial,
                solutionJavaScript: document.Solution
            });
        }
    };

    $scope.run = function () {
        if ($scope.htmlDocuments.length > 1) {
            throw new Error("Multiple HTML documents are not yet supported");
        }

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
            $scope.parseHtmlDocuments(data.HtmlDocuments);
            $scope.parseJavaScriptDocuments(data.JavaScriptDocuments);
            $scope.headIncludes = data.headIncludes;
            $scope.scriptIncludes = data.scriptIncludes;
        })
        .error(function (data, status, headers, config) {
            alert("Error!");
        });
    };
}]);
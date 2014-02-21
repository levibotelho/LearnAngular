angular.module('AngularTutorial', ["ui.ace"]).controller('IndexController', ["$scope", "$http", "$sce", function ($scope, $http, $sce) {
    $scope.tableOfContents = null;
    $scope.title = "";
    $scope.instructions = "";
    $scope.htmlDocuments = [];
    $scope.javaScriptDocuments = [];
    $scope.headIncludes = null;
    $scope.scriptIncludes = null;

    $scope.areEditableDocuments = function() {
        return $scope.htmlDocuments.length != 0 || $scope.javaScriptDocuments.length != 0;
    };

    $scope.run = function () {
        var frame = window.frames[0].document;
        var document = $scope.generateDocument();
        frame.open();
        frame.write(document);
        frame.close();
    };

    $scope.generateDocument = function () {
        if ($scope.htmlDocuments.length > 1) {
            throw new Error("Multiple HTML documents are not yet supported");
        }

        var htmlDocument = $scope.htmlDocuments[0];
        var scriptBlock = $scope.generateScriptBlock();
        var baseDocument = $scope.generateBaseHtmlDocument(htmlDocument.header, htmlDocument.html, htmlDocument.footer);
        baseDocument = $scope.insertHeadIncludes(baseDocument);
        baseDocument = $scope.insertScript(baseDocument, scriptBlock);
        return baseDocument;
    };

    $scope.generateBaseHtmlDocument = function (header, body, footer) {
        var document = "";
        if (header != null)
            document += header + "\n";
        if (body != null)
            document += body + "\n";
        if (footer != null) {
            document += footer + "\n";
        }

        return document.trim();
    };

    $scope.generateScriptBlock = function () {
        var scriptBlock = "";
        for (var i = 0; i < $scope.javaScriptDocuments.length; i++) {
            var document = $scope.javaScriptDocuments[i];
            scriptBlock += "// " + document.name + "\n" + document.javaScript + "\n";
        }

        return scriptBlock.trim();
    };

    $scope.insertHeadIncludes = function (document) {
        if ($scope.headIncludes == null)
            return document;

        var insertIndex = document.indexOf("</head>");
        if (insertIndex == -1) {
            throw new Error("A </head> element is required to insert head includes.");
        }

        return document.substr(0, insertIndex) + $scope.headIncludes + document.substr(insertIndex) + "\n";
    };

    $scope.insertScript = function (document, scriptBlock) {
        if (scriptBlock == null) {
            return document;
        }

        var insertIndex = document.indexOf("<script>");
        if (insertIndex == -1) {
            insertIndex = document.indexOf("</body>");
            if (insertIndex == -1) {
                insertIndex = document.indexOf("</html>");
                if (insertIndex == -1) {
                    insertIndex = document.length;
                }
            }
        }

        var scripts = $scope.scriptIncludes != null ? $scope.scriptIncludes + "\n" : "";
        scripts += "<script>\n" + scriptBlock + "\n</script>\n";
        return document.substr(0, insertIndex) + scripts + document.substr(insertIndex);
    };

    $scope.showSolution = function () {
        for (var i = 0; i < $scope.htmlDocuments.length; i++) {
            var htmlDocument = $scope.htmlDocuments[i];
            htmlDocument.html = htmlDocument.solutionHtml;
        }
        for (var j = 0; j < $scope.javaScriptDocuments.length; j++) {
            var javaScriptDocument = $scope.javaScriptDocuments[j];
            javaScriptDocument.javaScript = javaScriptDocument.solutionJavaScript;
        }
    };

    $scope.resetCode = function () {
        for (var i = 0; i < $scope.htmlDocuments.length; i++) {
            var htmlDocument = $scope.htmlDocuments[i];
            htmlDocument.html = htmlDocument.initialHtml;
        }
        for (var j = 0; j < $scope.javaScriptDocuments.length; j++) {
            var javaScriptDocument = $scope.javaScriptDocuments[j];
            javaScriptDocument.javaScript = javaScriptDocument.initialJavaScript;
        }
    };
    
    $scope.loadStep = function (id) {
        $http.get("/Home/GetStep", { params: { id: id } })
        // data, status, headers, config
        .success(function (data) {
            $scope.title = data.Title;
            $scope.instructions = $sce.trustAs("html", data.Instructions);
            $scope.parseHtmlDocuments(data.HtmlDocuments);
            $scope.parseJavaScriptDocuments(data.JavaScriptDocuments);
            $scope.headIncludes = $scope.parseIncludes(data.HeadIncludes);
            $scope.scriptIncludes = $scope.parseIncludes(data.ScriptIncludes);
        })
        .error(function () {
            alert("An unexpected error has occured. Please try again.");
        });
    };

    $scope.parseHtmlDocuments = function (documents) {
        $scope.htmlDocuments.length = 0;
        if (documents == null)
            return;

        for (var i = 0; i < documents.length; i++) {
            var document = documents[i];
            $scope.htmlDocuments.push({
                name: document.Name,
                id: $scope.generateDocumentId(document.Name),
                header: document.Header,
                html: document.Initial,
                initialHtml: document.Initial,
                solutionHtml: document.Solution,
                footer: document.Footer
            });
        }
    };

    $scope.parseJavaScriptDocuments = function (documents) {
        $scope.javaScriptDocuments.length = 0;
        if (documents == null)
            return;

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

    $scope.generateDocumentId = function (name) {
        if (name == null)
            throw new Error("name cannot be null");
        return name.replace(".", "");
    };

    $scope.parseIncludes = function (includes) {
        return includes != null ? includes.join("\n") : null;
    };

    $scope.loadTableOfContents = function () {
        $http.get("/Home/GetTableOfContents")
            .success(function (data) {
                $scope.tableOfContents = data;
                $scope.loadStep($scope.tableOfContents[0].Children[0].Id);
            })
            .error(function () {
                alert("An unexpected error has occured. Please try again.");
            });
    };

    $scope.loadTableOfContents();
}]);
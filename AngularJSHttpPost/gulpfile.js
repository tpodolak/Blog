/// <binding Clean='clean' />

var gulp = require("gulp"),
    fs = require("fs"),
    jshint = require('gulp-jshint'),
    concat = require('gulp-concat'),
    lazypipe = require('lazypipe'),
    runsequence = require('run-sequence'),
    ngAnnotate = require('gulp-ng-annotate'),
    gulpClean = require('gulp-clean');

eval("var project = " + fs.readFileSync("./project.json"));

var paths = {
    bower: "./bower_components/",
    lib: "./" + project.webroot + "/lib/",
    appDest: "./" + project.webroot + "/app/",
    appSrc: '.app/',
    appScripts: ['app/**/*.js']
};

var constants = {
    appAll: 'app.all.js'
}

var jsLintTask = lazypipe().pipe(jshint, '.jshintrc')
    .pipe(jshint.reporter, 'jshint-stylish')
    .pipe(jshint.reporter, 'fail');

var annotateTask = lazypipe().pipe(ngAnnotate);

var concatJsTask = lazypipe().pipe(concat, constants.appAll);

gulp.task("clean", function () {
    return gulp.src([paths.appDest, paths.lib, project.webroot + '/index.html'])
               .pipe(gulpClean());
});

gulp.task("copy", function () {
    var bower = {
        "bootstrap": "bootstrap/dist/**/*.{js,map,css,ttf,svg,woff,eot}",
        "jquery": "jquery/jquery*.{js,map}",
        "jquery-validation": "jquery-validation/jquery.validate.js",
        "jquery-validation-unobtrusive": "jquery-validation-unobtrusive/jquery.validate.unobtrusive.js",
        "angular": "angular/angular*.{js,map}",
        "angular-route": "angular-route/angular-route*.{js,map}",
        "normalize-css": "normalize-css/normalize.css"
    }

    for (var destinationDir in bower) {
        if (bower.hasOwnProperty(destinationDir)) {
            gulp.src(paths.bower + bower[destinationDir])
                .pipe(gulp.dest(paths.lib + destinationDir));
        }
    }

    gulp.src(['!.app/index.html', './app/**/*.html'], { base: './' })
        .pipe(gulp.dest('wwwroot'));

    gulp.src('./app/index.html')
        .pipe(gulp.dest('wwwroot'));
});

gulp.task('default', ['build']);
gulp.task('buildscripts', buildScripts);

gulp.task('build', function (callback) {
    runsequence('clean', 'copy', 'buildscripts', callback);
});

function buildScripts() {
    return gulp.src(paths.appScripts)
        .pipe(jsLintTask())
        .pipe(annotateTask())
        .pipe(concatJsTask())
        .pipe(gulp.dest(paths.appDest));
}

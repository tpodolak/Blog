var gulp = require('gulp'),
    jshint = require('gulp-jshint'),
    concat = require('gulp-concat'),
    lazypipe = require('lazypipe'),
    gulpClean = require('gulp-clean'),
    runsequence = require('run-sequence'),
    ngAnnotate = require('gulp-ng-annotate')
var paths = {
    scripts: ['app/**/*.js', '!app/bower_components/**/*.*'],
    scriptsDest: 'app'
};

var constants = {
    jsAllFileName: 'app.all.js'
}

var jsLintTask = lazypipe().pipe(jshint, '.jshintrc')
    .pipe(jshint.reporter, 'jshint-stylish')
    .pipe(jshint.reporter, 'fail');

var annotateTask = lazypipe().pipe(ngAnnotate);

var concatJsTask = lazypipe().pipe(concat, constants.jsAllFileName);

gulp.task('default', ['build']);
gulp.task('buildscripts', buildScripts);
gulp.task('clean', clean)

gulp.task('build', function (callback) {
    runsequence('clean', 'buildscripts', callback);
});

function buildScripts() {
    return gulp.src(paths.scripts)
        .pipe(jsLintTask())
        .pipe(annotateTask())
        .pipe(concatJsTask())
        .pipe(gulp.dest(paths.scriptsDest));
}

function clean() {
    return gulp.src([
        paths.scriptsDest + '/' + constants.jsAllFileName
    ], {
        read: false
    }).pipe(gulpClean());
};
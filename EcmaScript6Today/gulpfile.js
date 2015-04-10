var gulp = require('gulp'),
    jshint = require('gulp-jshint'),
    concat = require('gulp-concat'),
    lazypipe = require('lazypipe'),
    gulpClean = require('gulp-clean'),
    runsequence = require('run-sequence'),
    traceur = require('gulp-traceur'),
    sourcemaps = require('gulp-sourcemaps'),
    argv = require('yargs').argv,
    babel = require('gulp-babel');
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


var concatJsTask = lazypipe().pipe(concat, constants.jsAllFileName);

gulp.task('default', ['build']);
gulp.task('buildscripts', buildScripts);
gulp.task('clean', clean)

gulp.task('build', function (callback) {
    if (!argv.babel && !argv.traceur) {
        var msg = 'Specify build type --babel to transpile using babel or --traceur to transpile using traceur';
        throw msg;
    }

    runsequence('clean', 'buildscripts', callback);
});

function buildScripts() {
    return gulp.src(paths.scripts)
        .pipe(jsLintTask())
        .pipe(sourcemaps.init())
        .pipe(argv.babel ? babel() : traceur())
        .pipe(concatJsTask())
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest(paths.scriptsDest));
}

function clean() {
    return gulp.src([
        paths.scriptsDest + '/' + constants.jsAllFileName
    ], {
        read: false
    }).pipe(gulpClean());
};
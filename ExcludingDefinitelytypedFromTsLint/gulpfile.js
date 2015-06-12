var gulp = require('gulp'),
    concat = require('gulp-concat'),
    gulpClean = require('gulp-clean'),
    runsequence = require('run-sequence'),
    ts = require('gulp-typescript'),
    tslint = require('gulp-tslint'),
    gulpFilter = require('gulp-filter'),
    sourcemaps = require('gulp-sourcemaps');

var constants = {
    appall: 'app.all.js'
}, paths = {
    typescripts: ['app/**/*.ts', 'typings/**/*.ts'],
    app: 'app/'
}

function clean() {
    return gulp.src([paths.app + constants.appall], {
        read: false
    }).pipe(gulpClean());
};

function buildTypeScriptWithoutFilter() {
    var filter = gulpFilter(['**/*.ts', '!**/*d.ts']);

    return gulp.src(paths.typescripts)
        .pipe(tslint())
        .pipe(tslint.report('prose', {
            emitError: true
        }))
        .pipe(sourcemaps.init())
        .pipe(ts({
            sortOutput: true,
            noExternalResolve: true,
            noEmitOnError: true,
            target: 'ES5'
        }))
        .pipe(concat(constants.appall))
        .pipe(sourcemaps.write())
        .pipe(gulp.dest(paths.app));
}

function buildTypeScriptWithFilter() {
    var filter = gulpFilter(['**/*.ts', '!**/*d.ts']);

    return gulp.src(paths.typescripts)
        .pipe(filter)
        .pipe(tslint())
        .pipe(tslint.report('prose', {
            emitError: true
        }))
        .pipe(filter.restore())
        .pipe(sourcemaps.init())
        .pipe(ts({
            sortOutput: true,
            noExternalResolve: true,
            noEmitOnError: true,
            target: 'ES5'
        }))
        .pipe(concat(constants.appall))
        .pipe(sourcemaps.write())
        .pipe(gulp.dest(paths.app));
}

gulp.task('clean', clean);
gulp.task('buildtypescriptwithoutfilter', buildTypeScriptWithoutFilter);
gulp.task('buildtypescriptwithfilter', buildTypeScriptWithFilter);
gulp.task('buildwithoutfilter', function (callback) {
    runsequence('clean', 'buildtypescriptwithoutfilter', callback);
});
gulp.task('buildwithfilter', function (callback) {
    runsequence('clean', 'buildtypescriptwithfilter', callback);
});


var _tl = $('#tubeLighter');
var _tlc = $('.controls');
var _this = _tl[0];
initLightTube();

function initLightTube() {
    $(function(){
        $('#tubeLighter').lightTube({
            initDispStyle :_this.getAttribute('data-style'),
            initOpacity: parseInt(_this.getAttribute('data-opacity'))/10,
            initRandFlushTime : _this.getAttribute('data-flushTime'),
            size: _this.getAttribute('data-size')
        });
    });
}
_tl.hover(function () {
    _tlc[0].style.display='';
    _tl[0].style.paddingTop = '0px';
}, function () {
    _tlc[0].style.display = 'none';
    _tl[0].style.paddingTop = '18px';
});

function nextOpacity() {
    if (_this.getAttribute('data-opacity') == '10')
    {
        _this.setAttribute('data-opacity','1');
    }else{
        _this.setAttribute('data-opacity', parseInt(_this.getAttribute('data-opacity')) + 1);
    }
    initLightTube();
}
function nextSize() {
    var sz = _this.getAttribute('data-size');
    switch (sz)
    {
        case 'medium':
            _this.setAttribute('data-size','large');
            break;
        case 'large':
            _this.setAttribute('data-size','small');
            break;
        case 'small':
            _this.setAttribute('data-size','medium');
            break;
    }
    initLightTube();
}
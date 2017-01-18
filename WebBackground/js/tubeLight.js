/**
 * @licence MIT
 * tubeLight.js
 * @author ming
 * Requires jQuery
 */
(function ($) {
    $.fn.extend({
        lightTube: function lightTube(options) {
            var tl_settings = $.extend({
                initDispStyle: 0, // 0=HH:mm:ss 1=0.HHmmss 2 = 0.6 random digits
                initOpacity: 0.0,
                initRandFlushTime: 500,
                size: 'medium'
            }, options);
            var dispStyle = tl_settings.initDispStyle;
            return this.each(function lightTubeEach() {
                var digitsArray = new Array(8);
                var dpanel;
                var curIntv;
                if ($('#dPanel').length > 0) {
                    $('#dPanel').empty();
                    dpanel = $('#dPanel')[0];
                    var intv = parseInt(dpanel.getAttribute('data-intv'));
                    clearInterval(intv);
                } else {
                    dpanel = document.createElement('div');
                    dpanel.className = 'digitsPanel';
                    dpanel.id = 'dPanel';
                }
                dpanel.style.opacity = tl_settings.initOpacity;

                for (i = 0; i < 8; i++) {
                    digitsArray[i] = document.createElement('img');
                    digitsArray[i].className = 'lightDigit ' + tl_settings.size;
                    digitsArray[i].setAttribute('data-id', i);
                    digitsArray[i].src = '';
                    dpanel.appendChild(digitsArray[i]);
                }

                this.appendChild(dpanel);
                $(this).draggable({
                    stop: function(event, ui) {
                        // event.toElement is the element that was responsible
                        // for triggering this event. The handle, in case of a draggable.
                        $( event.originalEvent.target ).one('click', function(e){ e.stopImmediatePropagation(); } );
                    }
                });
                dpanel.onclick = function () {
                    //var this = $('#tubeLighter')[0];
                    if (_this.getAttribute('data-style') == 2) {
                        _this.setAttribute('data-style', 0);
                    } else {
                        _this.setAttribute('data-style', parseInt(_this.getAttribute('data-style')) + 1)
                    }
                    initLightTube();
                };
                var getSrcStr = function (i) {
                    return "img/lightTube/" + i + ".png"
                };
                if (dispStyle == 2) {
                    curIntv = setInterval(function () {
                        var digits = $('.lightDigit').each(function () {
                            if (!(this.getAttribute('data-id') == 0 || this.getAttribute('data-id') == 1)) {
                                this.src = getSrcStr(Math.floor(Math.random() * 10));
                            }
                            if (this.getAttribute('data-id') == 1) {
                                if (this.src.indexOf("Rvt") >= 1) {
                                    this.src = "img/lightTube/dot.png";
                                } else {
                                    this.src = "img/lightTube/dotRvt.png";
                                }
                            }
                            if (this.getAttribute('data-id') == 0) {
                                this.src = "img/lightTube/0.png";
                            }
                        });
                    }, tl_settings.initRandFlushTime);
                    dpanel.setAttribute('data-intv', curIntv);
                } else {
                    if (dispStyle == 1) {
                        curIntv = setInterval(function () {
                            var _time = new Date();
                            $('.lightDigit').each(function () {
                                switch (parseInt(this.getAttribute('data-id'))) {
                                    case 0:
                                        this.src = "img/lightTube/0.png";
                                        break;
                                    case 1:
                                        if (this.src.indexOf("Rvt") >= 1) {
                                            this.src = "img/lightTube/dot.png";
                                        } else {
                                            this.src = "img/lightTube/dotRvt.png";
                                        }
                                        break;
                                    case 2:
                                        this.src = getSrcStr(Math.floor(_time.getHours() / 10));
                                        break;
                                    case 3:
                                        this.src = getSrcStr(_time.getHours() % 10);
                                        break;
                                    case 4:
                                        this.src = getSrcStr(Math.floor(_time.getMinutes() / 10));
                                        break;
                                    case 5:
                                        this.src = getSrcStr(_time.getMinutes() % 10);
                                        break;
                                    case 6:
                                        this.src = getSrcStr(Math.floor(_time.getSeconds() / 10));
                                        break;
                                    case 7:
                                        this.src = getSrcStr(_time.getSeconds() % 10);
                                }
                            });
                        }, 1000);
                        dpanel.setAttribute('data-intv', curIntv);
                    } else {
                        curIntv = setInterval(function () {
                            var _time = new Date();
                            $('.lightDigit').each(function () {
                                switch (parseInt(this.getAttribute('data-id'))) {
                                    case 0:
                                        this.src = getSrcStr(Math.floor(_time.getHours() / 10));
                                        break;
                                    case 1:
                                        this.src = getSrcStr(_time.getHours() % 10);
                                        break;
                                    case 2:
                                        if (this.src.indexOf("Rvt") >= 1) {
                                            this.src = "img/lightTube/dot.png";
                                        } else {
                                            this.src = "img/lightTube/dotRvt.png";
                                        }
                                        break;
                                    case 3:
                                        this.src = getSrcStr(Math.floor(_time.getMinutes() / 10));
                                        break;
                                    case 4:
                                        this.src = getSrcStr(_time.getMinutes() % 10);
                                        break;
                                    case 5:
                                        if (this.src.indexOf("Rvt") >= 1) {
                                            this.src = "img/lightTube/dot.png";
                                        } else {
                                            this.src = "img/lightTube/dotRvt.png";
                                        }
                                        break;
                                    case 6:
                                        this.src = getSrcStr(Math.floor(_time.getSeconds() / 10));
                                        break;
                                    case 7:
                                        this.src = getSrcStr(_time.getSeconds() % 10);
                                }
                            });
                        }, 1000);
                        dpanel.setAttribute('data-intv', curIntv);
                    }
                }
            })
        }
    });
}(jQuery))
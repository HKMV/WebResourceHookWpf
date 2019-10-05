/*!
 * LMV v7.3.0
 * 
 * Copyright 2019 Autodesk, Inc.
 * All rights reserved.
 * 
 * This computer source code and related instructions and comments are the
 * unpublished confidential and proprietary information of Autodesk, Inc.
 * and are protected under Federal copyright and state trade secret law.
 * They may not be disclosed to, copied or used by any third party without
 * the prior written consent of Autodesk, Inc.
 * 
 * Autodesk Forge Viewer Usage Limitations:
 * 
 * The Autodesk Forge viewer can only be used to view files generated by
 * Autodesk Forge services. The Autodesk Forge Viewer JavaScript must be
 * delivered from an Autodesk hosted URL.
 */
Autodesk.Extensions.ViewCubeUi =
/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, { enumerable: true, get: getter });
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 			Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 		}
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// create a fake namespace object
/******/ 	// mode & 1: value is a module id, require it
/******/ 	// mode & 2: merge all properties of value into the ns
/******/ 	// mode & 4: return value when already ns object
/******/ 	// mode & 8|1: behave like require
/******/ 	__webpack_require__.t = function(value, mode) {
/******/ 		if(mode & 1) value = __webpack_require__(value);
/******/ 		if(mode & 8) return value;
/******/ 		if((mode & 4) && typeof value === 'object' && value && value.__esModule) return value;
/******/ 		var ns = Object.create(null);
/******/ 		__webpack_require__.r(ns);
/******/ 		Object.defineProperty(ns, 'default', { enumerable: true, value: value });
/******/ 		if(mode & 2 && typeof value != 'string') for(var key in value) __webpack_require__.d(ns, key, function(key) { return value[key]; }.bind(null, key));
/******/ 		return ns;
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = "./extensions/ViewCubeUi/ViewCubeUi.js");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./extensions/ViewCubeUi/ViewCubeUi.css":
/*!**********************************************!*\
  !*** ./extensions/ViewCubeUi/ViewCubeUi.css ***!
  \**********************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {


var content = __webpack_require__(/*! !../../node_modules/css-loader!../../node_modules/sass-loader/dist/cjs.js!./ViewCubeUi.css */ "./node_modules/css-loader/index.js!./node_modules/sass-loader/dist/cjs.js!./extensions/ViewCubeUi/ViewCubeUi.css");

if(typeof content === 'string') content = [[module.i, content, '']];

var transform;
var insertInto;



var options = {"hmr":true}

options.transform = transform
options.insertInto = undefined;

var update = __webpack_require__(/*! ../../node_modules/style-loader/lib/addStyles.js */ "./node_modules/style-loader/lib/addStyles.js")(content, options);

if(content.locals) module.exports = content.locals;

if(false) {}

/***/ }),

/***/ "./extensions/ViewCubeUi/ViewCubeUi.js":
/*!*********************************************!*\
  !*** ./extensions/ViewCubeUi/ViewCubeUi.js ***!
  \*********************************************/
/*! exports provided: ViewCubeUi */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ViewCubeUi", function() { return ViewCubeUi; });
/* harmony import */ var _ViewCubeUi_css__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./ViewCubeUi.css */ "./extensions/ViewCubeUi/ViewCubeUi.css");
/* harmony import */ var _ViewCubeUi_css__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_ViewCubeUi_css__WEBPACK_IMPORTED_MODULE_0__);




var av = Autodesk.Viewing;
var avp = Autodesk.Viewing.Private;
var global = av.getGlobal();


/**
                              * Create the UI for the view cube.
                              * 
                              * The extension id is: `Autodesk.ViewCubeUi`
                              * 
                              * @example
                              *    viewer.loadExtension('Autodesk.ViewCubeUi');
                              * 
                              * @see {@link Autodesk.Viewing.Extension} for common inherited methods.
                              * @memberof Autodesk.Viewing.Extensions
                              * @alias Autodesk.Viewing.Extensions.ViewCubeUi
                              * @constructor
                              * @param {Autodesk.Viewing.Viewer3D} viewer - Viewer instance.
                              * @param {Object} options - Not used.
                              */
function ViewCubeUi(viewer, options) {
  av.Extension.call(this, viewer, options);
  // Keep the constructor LEAN
  // The actual initialization happens in create()
  this.container = null;
  this.cube = null; // Autocam.ViewCube
  this.viewcube = null;
  this.homeViewContainer = null;
  this._created = false;
  this._initTriadVisibility = false;
  this.refreshCube = this.refreshCube.bind(this);
  this.displayViewCube = this.displayViewCube.bind(this);

};

ViewCubeUi.prototype = {
  constructor: ViewCubeUi,

  /**
                            * @private
                            */
  load: function load() {
    this.create();
    // Do not display the ViewCube for 2d models 
    if (this.viewer.impl.is2d)
    this.displayViewCube(false);else

    this.displayViewCube(this.viewer.prefs.viewCube);

    this.localize();

    // Dispatch a view cube created event
    this.viewer.dispatchEvent({ type: av.VIEW_CUBE_CREATED_EVENT });

    // Refresh the cube when resizing
    this.viewer.addEventListener(av.VIEWER_RESIZE_EVENT, this.refreshCube);

    // Register the displayViewCube function as the callback for the viewCube preference.
    this.viewer.prefs.addListeners(Autodesk.Viewing.Private.Prefs3D.VIEW_CUBE, this.displayViewCube);
    return true;
  },

  /**
      * Destroy the view cube.
      * @private
      */
  unload: function unload() {
    this.viewer.prefs.removeListeners(Autodesk.Viewing.Private.Prefs3D.VIEW_CUBE, this.displayViewCube);
    this.viewer.removeEventListener(av.VIEWER_RESIZE_EVENT, this.refreshCube);

    if (this.container) {
      this.viewer.container.removeChild(this.container);
      this.viewcube = null;
    }

    if (this.cube) {
      this.cube.dtor();
      this.cube = null;
    }

    this.homeViewContainer = null;
    this.hideHomeViewMenu = null;
    this.viewer = null;
    return true;
  },

  /**
      * Initialize the view cube and the home button.
      * This method is called when the extension is loaded.
      */
  create: function create() {
    if (this._created)
    return;
    this.initContainer();
    this.initHomeButton();
    this._created = true;
  },

  /**
      * @private
      */
  initContainer: function initContainer() {
    var _document = this.getDocument();
    this.container = _document.createElement('div');
    this.container.className = "viewcubeWrapper";
    this.viewer.container.appendChild(this.container);
  },

  /**
      * @private
      */
  initHomeButton: function initHomeButton() {
    if (this.homeViewContainer) {
      return;
    }

    var _document = this.getDocument();
    var homeViewContainer = _document.createElement('div');
    homeViewContainer.className = "homeViewWrapper";

    this.container.appendChild(homeViewContainer);
    this.homeViewContainer = homeViewContainer;

    var self = this;
    homeViewContainer.addEventListener("click", function (e) {
      self.viewer.navigation.setRequestHomeView(true);
    });
  },

  /**
      * Show or hide the view cube element. This also applies to the home button.
      * @param {Boolean} show - If set to false, the view cube and the home button will become invisible.
      * @alias Autodesk.Viewing.Extensions.ViewCubeUi#setVisible
      */
  setVisible: function setVisible(show) {
    this.container.style.display = show ? 'block' : 'none';
  },

  /**
      * Show the x,y,z axes of the view cube.
      * @param {Boolean} show - if set to true, the view cube axes will be shown.
      * @alias Autodesk.Viewing.Extensions.ViewCubeUi#showTriad
      */
  showTriad: function showTriad(show) {
    if (this.cube)
    this.cube.showTriad(show);else

    this._initTriadVisibility = show;
  },


  /**
      * Set the face of ViewCube and apply camera transformation according to it.
      *
      * @param {string} face - The face name of ViewCube. The name can contain multiple face names,
      * the format should be `"[front/back], [top/bottom], [left/right]"`.
      *
      * @example
      *    viewer.setViewCube('front top right');
      *    viewer.setViewCube('bottom left');
      *    viewer.setViewCube('back');
      * 
      * @alias Autodesk.Viewing.Extensions.ViewCubeUi#setViewCube
      */
  setViewCube: function setViewCube(face) {
    if (this.cube) {
      this.cube.cubeRotateTo(face);
    }
  },

  /**
      * Hides the Home button next to the ViewCube.
      *
      * @param {boolean} show
      * @alias Autodesk.Viewing.Extensions.ViewCubeUi#displayHomeButton
      */
  displayHomeButton: function displayHomeButton(show) {// show/hide home button.
    if (this.homeViewContainer)
    this.homeViewContainer.style.display = show ? '' : 'none';
  },

  /**
      * Display the view cube. This will not effect the home button.
      * @param {Boolean} display - if set to false the view cube element will be invisible
      * @param {Boolean} updatePrefs - update the view cube preference
      * @alias Autodesk.Viewing.Extensions.ViewCubeUi#displayViewCube
      */
  displayViewCube: function displayViewCube(display, updatePrefs) {
    if (updatePrefs)
    this.viewer.prefs.set('viewCube', display);

    if (display && !this.cube && !this.viewer.impl.is2d) {
      var _document = this.getDocument();
      this.viewcube = _document.createElement("div");
      this.viewcube.className = "viewcube";
      this.container.appendChild(this.viewcube);
      this.cube = new avp.ViewCube("cube", this.viewer.autocam, this.viewcube, global.LOCALIZATION_REL_PATH);
      this.cube.setGlobalManager(this.globalManager);

      // Move sibling on top of the viewcube.
      this.container.appendChild(this.homeViewContainer);

      if (this._initTriadVisibility) {
        this.showTriad(true);
      }
      delete this._initTriadVisibility;
    } else
    if (!this.cube) {
      this._positionHomeButton();
      return; //view cube is not existent and we want it off? Just do nothing.
    }

    this.viewcube.style.display = display ? "block" : "none";

    this._positionHomeButton();

    if (display) {
      this.viewer.autocam.refresh();
    }
  },

  /**
      * Localize the view cube
      * @alias Autodesk.Viewing.Extensions.ViewCubeUi#localize
      */
  localize: function localize() {
    this.cube && this.cube.localize();
  },

  /**
      * @private
      */
  _positionHomeButton: function _positionHomeButton() {
    if (this.homeViewContainer) {
      var viewCubeVisible = this.cube && this.viewcube && this.viewcube.style.display === 'block';
      if (viewCubeVisible) {
        this.homeViewContainer.classList.remove('no-viewcube');
      } else {
        this.homeViewContainer.classList.add('no-viewcube');
      }
    }
  },

  /**
      * Refresh the view cube
      * @alias Autodesk.Viewing.Extensions.ViewCubeUi#refreshCube
      */
  refreshCube: function refreshCube() {
    this.cube && this.cube.refreshCube();
  } };



/**
        * Register the extension with the extension manager.
        */
av.theExtensionManager.registerExtension('Autodesk.ViewCubeUi', ViewCubeUi);

/***/ }),

/***/ "./node_modules/css-loader/index.js!./node_modules/sass-loader/dist/cjs.js!./extensions/ViewCubeUi/ViewCubeUi.css":
/*!***************************************************************************************************************!*\
  !*** ./node_modules/css-loader!./node_modules/sass-loader/dist/cjs.js!./extensions/ViewCubeUi/ViewCubeUi.css ***!
  \***************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(/*! ../../node_modules/css-loader/lib/css-base.js */ "./node_modules/css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "/***\n * view cube\n */\n.viewcube, .viewcubeWrapper {\n  display: block;\n  position: absolute;\n  outline: none;\n  width: 150px;\n  height: 150px;\n  right: -5px;\n  top: -5px;\n  opacity: 0.7;\n  margin: 0;\n  -webkit-transition: opacity 0.2s ease;\n  -moz-transition: opacity 0.2s ease;\n  -ms-transition: opacity 0.2s ease;\n  -o-transition: opacity 0.2s ease;\n  transition: opacity 0.2s ease; }\n\n.viewcubeWrapper {\n  pointer-events: none; }\n\n.viewcube {\n  pointer-events: auto; }\n\n.rewindFrame {\n  background-color: #FFFFFF;\n  position: absolute;\n  height: 56px;\n  width: 56px;\n  z-index: 1002; }\n\n.dropDownMenu {\n  position: absolute;\n  min-width: 220px;\n  margin: 0;\n  z-index: 1001;\n  background-color: #FFFFFF;\n  font-family: sans-serif;\n  font-size: 14px;\n  list-style-type: none;\n  border: solid;\n  border-width: 1px;\n  border-color: #979797; }\n\n.dropDownMenuItem {\n  position: relative;\n  width: calc(100% - 24px);\n  height: 21px;\n  padding-left: 24px;\n  /* Pad room for checkboxes */\n  padding-top: 4px;\n  background-color: #FFFFFF;\n  cursor: pointer; }\n\n.dropDownMenuCheckbox {\n  position: relative;\n  width: calc(100% - 4px);\n  padding-top: 4px;\n  height: 21px;\n  margin-left: 4px;\n  background-color: #FFFFFF;\n  cursor: pointer; }\n\n.dropDownMenuCheck {\n  padding-top: 2px;\n  cursor: pointer; }\n\n.dropDownMenuCheckText {\n  position: relative;\n  padding-left: 2px;\n  margin: 0;\n  cursor: pointer; }\n\n.dropDownMenuItemDisabled {\n  color: #999999;\n  position: relative;\n  width: calc(100% - 5px);\n  height: 23px;\n  background-color: #FFFFFF;\n  cursor: pointer; }\n\n.dropDownMenuItem:hover {\n  background-color: #E7EEF6; }\n\n.dropDownMenuCheckbox:hover {\n  background-color: #E7EEF6; }\n\n.textBox {\n  font-size: 15px;\n  background-color: #000;\n  opacity: 0.6;\n  padding: 2px 10px;\n  border-radius: 2px;\n  position: fixed;\n  display: none;\n  font-family: Monospace;\n  color: #fff;\n  z-index: 1000; }\n\n#colorCode {\n  position: absolute;\n  left: 0px;\n  top: 0px; }\n\n#text, #steeringWheel {\n  position: absolute;\n  left: 0px;\n  top: 0px;\n  z-index: 900; }\n\n.homeViewWrapper {\n  display: block;\n  outline: none;\n  margin: 18px 0px 0px -20px;\n  opacity: 0.7;\n  width: 24px;\n  height: 24px;\n  background-image: url(data:image/png;base64,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);\n  cursor: pointer;\n  pointer-events: auto; }\n\n.homeViewWrapper:hover {\n  opacity: 1; }\n\n.homeViewWrapper.no-viewcube {\n  position: absolute;\n  right: 12px;\n  top: 10px;\n  margin: 0; }\n\n.homeViewMenu {\n  display: none;\n  position: absolute;\n  right: 10px;\n  top: 28px;\n  background-color: #FFFFFF;\n  border: 1px solid #979797;\n  z-index: 1; }\n\n.homeViewMenuItem {\n  padding: 5px 20px;\n  font-family: sans-serif;\n  font-size: 14px;\n  cursor: pointer;\n  z-index: 2; }\n\n.homeViewMenuItem:hover {\n  background-color: #E7EEF6; }\n\n.homeViewWrapper .homeViewMenuHandle {\n  display: none;\n  position: relative;\n  left: 18px;\n  top: 18px; }\n", ""]);

// exports


/***/ }),

/***/ "./node_modules/css-loader/lib/css-base.js":
/*!*************************************************!*\
  !*** ./node_modules/css-loader/lib/css-base.js ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

/*
	MIT License http://www.opensource.org/licenses/mit-license.php
	Author Tobias Koppers @sokra
*/
// css base code, injected by the css-loader
module.exports = function(useSourceMap) {
	var list = [];

	// return the list of modules as css string
	list.toString = function toString() {
		return this.map(function (item) {
			var content = cssWithMappingToString(item, useSourceMap);
			if(item[2]) {
				return "@media " + item[2] + "{" + content + "}";
			} else {
				return content;
			}
		}).join("");
	};

	// import a list of modules into the list
	list.i = function(modules, mediaQuery) {
		if(typeof modules === "string")
			modules = [[null, modules, ""]];
		var alreadyImportedModules = {};
		for(var i = 0; i < this.length; i++) {
			var id = this[i][0];
			if(typeof id === "number")
				alreadyImportedModules[id] = true;
		}
		for(i = 0; i < modules.length; i++) {
			var item = modules[i];
			// skip already imported module
			// this implementation is not 100% perfect for weird media query combinations
			//  when a module is imported multiple times with different media queries.
			//  I hope this will never occur (Hey this way we have smaller bundles)
			if(typeof item[0] !== "number" || !alreadyImportedModules[item[0]]) {
				if(mediaQuery && !item[2]) {
					item[2] = mediaQuery;
				} else if(mediaQuery) {
					item[2] = "(" + item[2] + ") and (" + mediaQuery + ")";
				}
				list.push(item);
			}
		}
	};
	return list;
};

function cssWithMappingToString(item, useSourceMap) {
	var content = item[1] || '';
	var cssMapping = item[3];
	if (!cssMapping) {
		return content;
	}

	if (useSourceMap && typeof btoa === 'function') {
		var sourceMapping = toComment(cssMapping);
		var sourceURLs = cssMapping.sources.map(function (source) {
			return '/*# sourceURL=' + cssMapping.sourceRoot + source + ' */'
		});

		return [content].concat(sourceURLs).concat([sourceMapping]).join('\n');
	}

	return [content].join('\n');
}

// Adapted from convert-source-map (MIT)
function toComment(sourceMap) {
	// eslint-disable-next-line no-undef
	var base64 = btoa(unescape(encodeURIComponent(JSON.stringify(sourceMap))));
	var data = 'sourceMappingURL=data:application/json;charset=utf-8;base64,' + base64;

	return '/*# ' + data + ' */';
}


/***/ }),

/***/ "./node_modules/style-loader/lib/addStyles.js":
/*!****************************************************!*\
  !*** ./node_modules/style-loader/lib/addStyles.js ***!
  \****************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

/*
	MIT License http://www.opensource.org/licenses/mit-license.php
	Author Tobias Koppers @sokra
*/

var stylesInDom = {};

var	memoize = function (fn) {
	var memo;

	return function () {
		if (typeof memo === "undefined") memo = fn.apply(this, arguments);
		return memo;
	};
};

var isOldIE = memoize(function () {
	// Test for IE <= 9 as proposed by Browserhacks
	// @see http://browserhacks.com/#hack-e71d8692f65334173fee715c222cb805
	// Tests for existence of standard globals is to allow style-loader
	// to operate correctly into non-standard environments
	// @see https://github.com/webpack-contrib/style-loader/issues/177
	return window && document && document.all && !window.atob;
});

var getTarget = function (target, parent) {
  if (parent){
    return parent.querySelector(target);
  }
  return document.querySelector(target);
};

var getElement = (function (fn) {
	var memo = {};

	return function(target, parent) {
                // If passing function in options, then use it for resolve "head" element.
                // Useful for Shadow Root style i.e
                // {
                //   insertInto: function () { return document.querySelector("#foo").shadowRoot }
                // }
                if (typeof target === 'function') {
                        return target();
                }
                if (typeof memo[target] === "undefined") {
			var styleTarget = getTarget.call(this, target, parent);
			// Special case to return head of iframe instead of iframe itself
			if (window.HTMLIFrameElement && styleTarget instanceof window.HTMLIFrameElement) {
				try {
					// This will throw an exception if access to iframe is blocked
					// due to cross-origin restrictions
					styleTarget = styleTarget.contentDocument.head;
				} catch(e) {
					styleTarget = null;
				}
			}
			memo[target] = styleTarget;
		}
		return memo[target]
	};
})();

var singleton = null;
var	singletonCounter = 0;
var	stylesInsertedAtTop = [];

var	fixUrls = __webpack_require__(/*! ./urls */ "./node_modules/style-loader/lib/urls.js");

module.exports = function(list, options) {
	if (typeof DEBUG !== "undefined" && DEBUG) {
		if (typeof document !== "object") throw new Error("The style-loader cannot be used in a non-browser environment");
	}

	options = options || {};

	options.attrs = typeof options.attrs === "object" ? options.attrs : {};

	// Force single-tag solution on IE6-9, which has a hard limit on the # of <style>
	// tags it will allow on a page
	if (!options.singleton && typeof options.singleton !== "boolean") options.singleton = isOldIE();

	// By default, add <style> tags to the <head> element
        if (!options.insertInto) options.insertInto = "head";

	// By default, add <style> tags to the bottom of the target
	if (!options.insertAt) options.insertAt = "bottom";

	var styles = listToStyles(list, options);

	addStylesToDom(styles, options);

	return function update (newList) {
		var mayRemove = [];

		for (var i = 0; i < styles.length; i++) {
			var item = styles[i];
			var domStyle = stylesInDom[item.id];

			domStyle.refs--;
			mayRemove.push(domStyle);
		}

		if(newList) {
			var newStyles = listToStyles(newList, options);
			addStylesToDom(newStyles, options);
		}

		for (var i = 0; i < mayRemove.length; i++) {
			var domStyle = mayRemove[i];

			if(domStyle.refs === 0) {
				for (var j = 0; j < domStyle.parts.length; j++) domStyle.parts[j]();

				delete stylesInDom[domStyle.id];
			}
		}
	};
};

function addStylesToDom (styles, options) {
	for (var i = 0; i < styles.length; i++) {
		var item = styles[i];
		var domStyle = stylesInDom[item.id];

		if(domStyle) {
			domStyle.refs++;

			for(var j = 0; j < domStyle.parts.length; j++) {
				domStyle.parts[j](item.parts[j]);
			}

			for(; j < item.parts.length; j++) {
				domStyle.parts.push(addStyle(item.parts[j], options));
			}
		} else {
			var parts = [];

			for(var j = 0; j < item.parts.length; j++) {
				parts.push(addStyle(item.parts[j], options));
			}

			stylesInDom[item.id] = {id: item.id, refs: 1, parts: parts};
		}
	}
}

function listToStyles (list, options) {
	var styles = [];
	var newStyles = {};

	for (var i = 0; i < list.length; i++) {
		var item = list[i];
		var id = options.base ? item[0] + options.base : item[0];
		var css = item[1];
		var media = item[2];
		var sourceMap = item[3];
		var part = {css: css, media: media, sourceMap: sourceMap};

		if(!newStyles[id]) styles.push(newStyles[id] = {id: id, parts: [part]});
		else newStyles[id].parts.push(part);
	}

	return styles;
}

function insertStyleElement (options, style) {
	var target = getElement(options.insertInto)

	if (!target) {
		throw new Error("Couldn't find a style target. This probably means that the value for the 'insertInto' parameter is invalid.");
	}

	var lastStyleElementInsertedAtTop = stylesInsertedAtTop[stylesInsertedAtTop.length - 1];

	if (options.insertAt === "top") {
		if (!lastStyleElementInsertedAtTop) {
			target.insertBefore(style, target.firstChild);
		} else if (lastStyleElementInsertedAtTop.nextSibling) {
			target.insertBefore(style, lastStyleElementInsertedAtTop.nextSibling);
		} else {
			target.appendChild(style);
		}
		stylesInsertedAtTop.push(style);
	} else if (options.insertAt === "bottom") {
		target.appendChild(style);
	} else if (typeof options.insertAt === "object" && options.insertAt.before) {
		var nextSibling = getElement(options.insertAt.before, target);
		target.insertBefore(style, nextSibling);
	} else {
		throw new Error("[Style Loader]\n\n Invalid value for parameter 'insertAt' ('options.insertAt') found.\n Must be 'top', 'bottom', or Object.\n (https://github.com/webpack-contrib/style-loader#insertat)\n");
	}
}

function removeStyleElement (style) {
	if (style.parentNode === null) return false;
	style.parentNode.removeChild(style);

	var idx = stylesInsertedAtTop.indexOf(style);
	if(idx >= 0) {
		stylesInsertedAtTop.splice(idx, 1);
	}
}

function createStyleElement (options) {
	var style = document.createElement("style");

	if(options.attrs.type === undefined) {
		options.attrs.type = "text/css";
	}

	if(options.attrs.nonce === undefined) {
		var nonce = getNonce();
		if (nonce) {
			options.attrs.nonce = nonce;
		}
	}

	addAttrs(style, options.attrs);
	insertStyleElement(options, style);

	return style;
}

function createLinkElement (options) {
	var link = document.createElement("link");

	if(options.attrs.type === undefined) {
		options.attrs.type = "text/css";
	}
	options.attrs.rel = "stylesheet";

	addAttrs(link, options.attrs);
	insertStyleElement(options, link);

	return link;
}

function addAttrs (el, attrs) {
	Object.keys(attrs).forEach(function (key) {
		el.setAttribute(key, attrs[key]);
	});
}

function getNonce() {
	if (false) {}

	return __webpack_require__.nc;
}

function addStyle (obj, options) {
	var style, update, remove, result;

	// If a transform function was defined, run it on the css
	if (options.transform && obj.css) {
	    result = typeof options.transform === 'function'
		 ? options.transform(obj.css) 
		 : options.transform.default(obj.css);

	    if (result) {
	    	// If transform returns a value, use that instead of the original css.
	    	// This allows running runtime transformations on the css.
	    	obj.css = result;
	    } else {
	    	// If the transform function returns a falsy value, don't add this css.
	    	// This allows conditional loading of css
	    	return function() {
	    		// noop
	    	};
	    }
	}

	if (options.singleton) {
		var styleIndex = singletonCounter++;

		style = singleton || (singleton = createStyleElement(options));

		update = applyToSingletonTag.bind(null, style, styleIndex, false);
		remove = applyToSingletonTag.bind(null, style, styleIndex, true);

	} else if (
		obj.sourceMap &&
		typeof URL === "function" &&
		typeof URL.createObjectURL === "function" &&
		typeof URL.revokeObjectURL === "function" &&
		typeof Blob === "function" &&
		typeof btoa === "function"
	) {
		style = createLinkElement(options);
		update = updateLink.bind(null, style, options);
		remove = function () {
			removeStyleElement(style);

			if(style.href) URL.revokeObjectURL(style.href);
		};
	} else {
		style = createStyleElement(options);
		update = applyToTag.bind(null, style);
		remove = function () {
			removeStyleElement(style);
		};
	}

	update(obj);

	return function updateStyle (newObj) {
		if (newObj) {
			if (
				newObj.css === obj.css &&
				newObj.media === obj.media &&
				newObj.sourceMap === obj.sourceMap
			) {
				return;
			}

			update(obj = newObj);
		} else {
			remove();
		}
	};
}

var replaceText = (function () {
	var textStore = [];

	return function (index, replacement) {
		textStore[index] = replacement;

		return textStore.filter(Boolean).join('\n');
	};
})();

function applyToSingletonTag (style, index, remove, obj) {
	var css = remove ? "" : obj.css;

	if (style.styleSheet) {
		style.styleSheet.cssText = replaceText(index, css);
	} else {
		var cssNode = document.createTextNode(css);
		var childNodes = style.childNodes;

		if (childNodes[index]) style.removeChild(childNodes[index]);

		if (childNodes.length) {
			style.insertBefore(cssNode, childNodes[index]);
		} else {
			style.appendChild(cssNode);
		}
	}
}

function applyToTag (style, obj) {
	var css = obj.css;
	var media = obj.media;

	if(media) {
		style.setAttribute("media", media)
	}

	if(style.styleSheet) {
		style.styleSheet.cssText = css;
	} else {
		while(style.firstChild) {
			style.removeChild(style.firstChild);
		}

		style.appendChild(document.createTextNode(css));
	}
}

function updateLink (link, options, obj) {
	var css = obj.css;
	var sourceMap = obj.sourceMap;

	/*
		If convertToAbsoluteUrls isn't defined, but sourcemaps are enabled
		and there is no publicPath defined then lets turn convertToAbsoluteUrls
		on by default.  Otherwise default to the convertToAbsoluteUrls option
		directly
	*/
	var autoFixUrls = options.convertToAbsoluteUrls === undefined && sourceMap;

	if (options.convertToAbsoluteUrls || autoFixUrls) {
		css = fixUrls(css);
	}

	if (sourceMap) {
		// http://stackoverflow.com/a/26603875
		css += "\n/*# sourceMappingURL=data:application/json;base64," + btoa(unescape(encodeURIComponent(JSON.stringify(sourceMap)))) + " */";
	}

	var blob = new Blob([css], { type: "text/css" });

	var oldSrc = link.href;

	link.href = URL.createObjectURL(blob);

	if(oldSrc) URL.revokeObjectURL(oldSrc);
}


/***/ }),

/***/ "./node_modules/style-loader/lib/urls.js":
/*!***********************************************!*\
  !*** ./node_modules/style-loader/lib/urls.js ***!
  \***********************************************/
/*! no static exports found */
/***/ (function(module, exports) {


/**
 * When source maps are enabled, `style-loader` uses a link element with a data-uri to
 * embed the css on the page. This breaks all relative urls because now they are relative to a
 * bundle instead of the current page.
 *
 * One solution is to only use full urls, but that may be impossible.
 *
 * Instead, this function "fixes" the relative urls to be absolute according to the current page location.
 *
 * A rudimentary test suite is located at `test/fixUrls.js` and can be run via the `npm test` command.
 *
 */

module.exports = function (css) {
  // get current location
  var location = typeof window !== "undefined" && window.location;

  if (!location) {
    throw new Error("fixUrls requires window.location");
  }

	// blank or null?
	if (!css || typeof css !== "string") {
	  return css;
  }

  var baseUrl = location.protocol + "//" + location.host;
  var currentDir = baseUrl + location.pathname.replace(/\/[^\/]*$/, "/");

	// convert each url(...)
	/*
	This regular expression is just a way to recursively match brackets within
	a string.

	 /url\s*\(  = Match on the word "url" with any whitespace after it and then a parens
	   (  = Start a capturing group
	     (?:  = Start a non-capturing group
	         [^)(]  = Match anything that isn't a parentheses
	         |  = OR
	         \(  = Match a start parentheses
	             (?:  = Start another non-capturing groups
	                 [^)(]+  = Match anything that isn't a parentheses
	                 |  = OR
	                 \(  = Match a start parentheses
	                     [^)(]*  = Match anything that isn't a parentheses
	                 \)  = Match a end parentheses
	             )  = End Group
              *\) = Match anything and then a close parens
          )  = Close non-capturing group
          *  = Match anything
       )  = Close capturing group
	 \)  = Match a close parens

	 /gi  = Get all matches, not the first.  Be case insensitive.
	 */
	var fixedCss = css.replace(/url\s*\(((?:[^)(]|\((?:[^)(]+|\([^)(]*\))*\))*)\)/gi, function(fullMatch, origUrl) {
		// strip quotes (if they exist)
		var unquotedOrigUrl = origUrl
			.trim()
			.replace(/^"(.*)"$/, function(o, $1){ return $1; })
			.replace(/^'(.*)'$/, function(o, $1){ return $1; });

		// already a full url? no change
		if (/^(#|data:|http:\/\/|https:\/\/|file:\/\/\/|\s*$)/i.test(unquotedOrigUrl)) {
		  return fullMatch;
		}

		// convert the url to a full url
		var newUrl;

		if (unquotedOrigUrl.indexOf("//") === 0) {
		  	//TODO: should we add protocol?
			newUrl = unquotedOrigUrl;
		} else if (unquotedOrigUrl.indexOf("/") === 0) {
			// path should be relative to the base url
			newUrl = baseUrl + unquotedOrigUrl; // already starts with '/'
		} else {
			// path should be relative to current directory
			newUrl = currentDir + unquotedOrigUrl.replace(/^\.\//, ""); // Strip leading './'
		}

		// send back the fixed url(...)
		return "url(" + JSON.stringify(newUrl) + ")";
	});

	// send back the fixed css
	return fixedCss;
};


/***/ })

/******/ });
//# sourceMappingURL=ViewCubeUi.js.map
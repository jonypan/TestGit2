/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.enterMode = CKEDITOR.ENTER_BR;
    config.toolbar = "Full";
    config.filebrowserBrowseUrl = '/Assets/admin/js/plugins/ckfinder/ckfinder.htm';
    config.filebrowserImageBrowseUrl = '/Assets/admin/js/plugins/ckfinder/ckfinder.htm?type=Images';
    config.filebrowserFlashBrowseUrl = '/Assets/admin/js/plugins/ckfinder/ckfinder.htm?type=Flash';
    config.filebrowserUploadUrl = '/Assets/admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Assets/admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = '/Assets/admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    config.filebrowserWindowWidth = '1000';
    config.filebrowserWindowHeight = '700'; 
    config.height = '800px';
    config.htmlEncode = true;

    CKFinder.setupCKEditor(null,"/Assets/admin/js/plugins/ckfinder/");
}; 
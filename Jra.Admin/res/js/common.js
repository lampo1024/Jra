
$(function () {

    // 从Cookie中读取设置参数
    var theme = F.cookie('Theme_JS') || 'default'; //default,custom_default,metro_blue,metro_dark_blue,cupertino
    var language = F.cookie('Language_JS') || 'zh_CN';
    var displayMode = F.cookie('MenuMode_JS') || 'normal';
    var loadingImageIndex = parseInt(F.cookie('Loading_JS'), 10) || 0;


    var largeMode = false, enableAnimation = false;
    // 移动端示例启用大字体和动画
    var href = location.href;
    if (location.hash) {
        href = href.substr(0, href.length - location.hash.length);
    }
    if (href.indexOf('/mobile/') > 0) {
        displayMode = 'large';
        enableAnimation = true;
    }


    // 初始化（添加主题及语言等相关引用）
    F.init({
        language: language,
        theme: theme,
        displayMode: displayMode,
        enableAnimation: enableAnimation,
        loadingImageIndex: loadingImageIndex,
        addThemeTag: true,      // 是否添加主题的引用标签（实际项目中，请直接在页面中添加主题样式链接）
        addLanguageTag: true    // 是否添加语言的引用标签（实际项目中，请直接在页面中添加语言脚本链接）
    });


});



// 公共方法 - 在顶层窗口弹出通知框
function showNotify(message, messageIcon) {
    F.notify({
        message: message,
        messageIcon: messageIcon,
        target: '_top',
        header: false,
        displayMilliseconds: 3000,
        positionX: 'center',
        positionY: 'top',
        closable: true
    });
}



// 显示居中通知对话框
function showCenterNotify(message, messageIcon) {
    F.notify({
        message: message,
        messageIcon: messageIcon || 'information',
        modal: true,
        hideOnMaskClick: true,
        header: false,
        displayMilliseconds: 3000,
        positionX: 'center',
        positionY: 'center',
        messageAlign: 'center',
        minWidth: 200,
        closable:true
    });
}
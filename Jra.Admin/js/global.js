//全局常量
window.C = {
    //api请求的基地址
    apiUrl: "http://localhost:60776/api/v1/",
    //登录地址
    loginUrl: "/account/login",
    //退出系统地址
    logoutUrl: "/home/logout",
    homePageUrl:"/home/index",
    //创建完整的api请求地址
    createUrl: function (resourceUrl) {
        return this.apiUrl + resourceUrl;
    },
    //默认表格分页大小
    gridPageSize: 25,
    //默认弹出表格分页大小
    popGridPageSize: 15,
    cookieKey: {
        accessToken: 'ACCESS_TOKEN'
    },
    auth: {
        isLogin: function () {
            var accessToken = C.auth.accessToken();
            if (!accessToken) {
                return false;
            }
            return true;
        },
        login: function (accessToken) {
            localStorage.setItem(C.cookieKey.accessToken, accessToken);
        },
        accessToken: function () {
            return localStorage.getItem(C.cookieKey.accessToken);
        },
        bearerToken: function () {
            return 'bearer ' + C.auth.accessToken();
        },
        logout: function () {
            localStorage.clear();
            F.alert({
                target: "_top",
                title: "提示信息",
                showLoading: true,
                message: "正在注销,请稍候...",
                messageIcon: '',
                closable: false
            });
            setTimeout(function () {
                window.top.location.href = C.logoutUrl;
            }, 2000);
        }
    }
};

//捕获全局Javascript错误
window.onerror = function (msg, url, line, col, error) {
    var errors = [];
    errors.push('消息：' + msg);
    errors.push('网址：' + url);
    errors.push('行：' + line);
    errors.push('列：' + col);

    F.alert(errors.join('<br/>'), 'JavaScript错误！', 'error');

    // 返回 true 阻止浏览器弹出错误提示框（比如在IE浏览器中）
    return true;
};
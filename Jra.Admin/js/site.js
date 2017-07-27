var isLogin = C.auth.isLogin();
if (!isLogin) {
    //window.top.location.href = C.loginUrl;
}

//window.D 用于存放常用下拉框的数据源
window.D = {
    status: function (optionText) {
        if (!optionText) {
            optionText = "--请选择--";
        }
        return {
            label: "状态",
            //包含不选择的下拉框数据源
            arrDataAll: [[-1, optionText], [0, "锁定"], [1, "正常"]],
            //不包含不选择的下拉框数据源
            arrData: [[0, "锁定"], [1, "正常"]],
            objDataAll: [{ value: -1, text: optionText }, { value: 0, text: "锁定" }, { value: 1, text: "正常" }],
            objData: [{ value: 0, text: "锁定" }, { value: 1, text: "正常" }]
        };
    },
    yesAndNo: function (optionText) {
        if (!optionText) {
            optionText = "--请选择--";
        }
        return {
            label: "是否",
            //包含不选择的下拉框数据源
            arrDataAll: [[-1, optionText], [0, "否"], [1, "是"]],
            //不包含不选择的下拉框数据源
            arrData: [[0, "否"], [1, "是"]],
            objDataAll: [{ value: -1, text: optionText }, { value: 0, text: "否" }, { value: 1, text: "是" }],
            objData: [{ value: 0, text: "否" }, { value: 1, text: "是" }]
        };
    },
    postKwType: [["title", "标题"], ["authorId", "作者ID"], ["authorName", "作者名称"]]
};

window.A = function () { };


// Add a request interceptor
//axios.defaults.baseURL = C.apiUrl;
//axios.defaults.headers.common['Authorization'] = 'bearer ' + C.auth.accessToken();
//axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';
//axios.interceptors.request.use(function (config) {
//    // Do something before request is sent
//    //console.info('before request...');
//    return config;
//}, function (error) {
//    // Do something with request error
//    return Promise.reject(error);
//});

var opened403 = false;
function show403Alert(message) {
    if (opened403) {
        return;
    }
    opened403 = true;
    F.alert({
        target: "_top",
        title: "提示信息",
        message: message,
        messageIcon: "error",
        ok:function() {
            opened403 = false;
            parent.removeActiveTab();
        }
    });
}

// Add a response interceptor
//axios.interceptors.response.use(function (response) {
//    // Do something with response data
//    return response;
//}, function (error) {
//    try {
//        if (error.response) {
//            var res = error.response;
//            console.info(res);
//            var message = '处理请求时遇到了问题,请稍候再试.';
//            if (res.data && res.data.message) {
//                message = res.data.message;
//            }
//            switch (res.status) {
//                case 401:
//                    // 401 清除token信息并跳转到登录页面
//                    //store.commit(types.LOGOUT);
//                    /*
//                    router.replace({
//                        path: 'login',
//                        query: {redirect: router.currentRoute.fullPath}
//                    })
//                    */
//                    //window.top.location.href = "/login.html";
//                    F.alert({
//                        target: "_top",
//                        title: "提示信息",
//                        message: "登录已失效,请重新登录",
//                        messageIcon: "warning",
//                        ok: function () {
//                            //清除ACCESS_TOKEN
//                            C.auth.logout();
//                        }
//                    });
//                    break;
//                case 403:
//                    show403Alert(message);
//                    break;
//                case 404:
//                    F.alert({
//                        target: "_top",
//                        title: "提示信息",
//                        message: "请求的服务器资源不存在[404]",
//                        messageIcon: "warning"
//                    });
//                    break;
//                default:
//                    F.alert({
//                        target: "_top",
//                        title: "提示信息",
//                        message: "出错啦,请稍候重试",
//                        messageIcon: "warning"
//                    });
//                    break;
//            }
//        }
//        var err = error + '';
//        if (err.indexOf("Network Error") > -1) {
//            F.alert({
//                target: "_top",
//                title: "网络出错",
//                message: "向服务器发起资源请求时出错,请检查你的网络或者联系管理员检查服务器运行状况.",
//                messageIcon: "warning"
//            });
//        }
//        return Promise.reject(error.response.data);
//    } catch (err) { }
//});

$.ajaxSetup({
    global: true,
    headers: { Authorization: 'bearer ' + C.auth.accessToken() }
});

//event, jqxhr, settings, exception
$(document).ajaxError(function (event, jqxhr) {
    switch (jqxhr.status) {
        case 401:
            F.alert({
                target: "_top",
                title: "提示信息",
                message: "登录已失效,请重新登录",
                messageIcon: "warning",
                ok: function () {
                    //退出系统
                    C.auth.logout();
                }
            });
            break;
        case 403:
            show403Alert(jqxhr.responseJSON.message);
            break;
        case 404:
            F.alert({
                target: "_top",
                title: "提示信息",
                message: "[404]请求的服务器资源不存在",
                messageIcon: "warning"
            });
            break;
        default:
            F.alert({
                target: "_top",
                title: "提示信息",
                message: "出错啦,请稍候重试",
                messageIcon: "error"
            });
            break;
    }
});
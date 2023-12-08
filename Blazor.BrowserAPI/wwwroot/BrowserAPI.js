export function clipboardWriteText(n){return navigator.clipboard.writeText(n)}export function clipboardReadText(){return navigator.clipboard.readText()}export function consoleAssert(n,t){console.assert(n,t)}export function consoleClear(){console.clear()}export function consoleCount(n){console.count(n)}export function consoleCountReset(n){console.countReset(n)}export function consoleDebug(n){console.debug(n)}export function consoleDir(n){console.dir(n)}export function consoleDirxml(n){console.dirxml(n)}export function consoleError(n){console.error(n)}export function consoleGroup(n){console.group(n)}export function consoleGroupCollapsed(n){console.groupCollapsed(n)}export function consoleGroupEnd(){console.groupEnd()}export function consoleInfo(n){console.info(n)}export function consoleLog(n){console.log(n)}export function consoleTable(n,t){console.table(n,t)}export function consoleTime(n){console.time(n)}export function consoleTimeEnd(n){console.timeEnd(n)}export function consoleTimeLog(n,t){t===undefined?console.timeLog(n):console.timeLog(n,t)}export function consoleTrace(n){console.trace(n)}export function consoleWarn(n){console.warn(n)}export function getAllCookies(){return document.cookie}export function cookieStorageLength(){if(document.cookie==="")return 0;let n=document.cookie.split(";");return n.length}export function cookieStorageKey(n){if(n<0)return null;let t=document.cookie.split(";");if(n>=t.length)return null;let i=t[n],r=i.split("=")[0];return r.trim()}export function cookieStorageGetCookie(n){let t=document.cookie.split(";");for(let i=0;i<t.length;i++){let r=t[i].split("="),u=r[0],f=r[1];if(u.trim()===n)return f.trim()}return null}export function cookieStorageSetCookie(n,t,i,r,u,f){let e=`${n}=${t}`;i!==null&&(e+=`;expires=${new Date(Date.now()+i).toUTCString()}`);e+=`;path=${r}`;e+=`;SameSite=${u}`;f&&(e+=";Secure");document.cookie=e}export function cookieStorageRemoveCookie(n){document.cookie=`${n}=;expires=Thu, 01 Jan 1970 00:00:00 GMT`}export function cookieStorageClear(){let n=document.cookie.split(";");for(let t=0;t<n.length;t++){let i=n[t].split("=")[0];document.cookie=`${i}=;expires=Thu, 01 Jan 1970 00:00:00 GMT`}}export function createDialog(n){return new DialogWrapper(n)}export async function downloadAsFile(n,t){const u=await t.arrayBuffer(),f=new Blob([u]),r=URL.createObjectURL(f),i=document.createElement("a");i.href=r;i.download=n;i.click();i.remove();URL.revokeObjectURL(r)}export function createHTMLElement(n){return new HTMLElementWrapper(n)}export function LanguageBrowser(){return navigator.language}export function LanguageHtmlRead(){return document.documentElement.lang}export function LanguageHtmlWrite(n){return document.documentElement.lang=n}export function localStorageLength(){return localStorage.length}export function localStorageKey(n){return localStorage.key(n)}export function localStorageGetItem(n){return localStorage.getItem(n)}export function localStorageSetItem(n,t){localStorage.setItem(n,t)}export function localStorageRemoveItem(n){localStorage.removeItem(n)}export function localStorageClear(){localStorage.clear()}export function createServiceWorker(n){return n===null?null:new ServiceWorkerWrapper(n)}export async function serviceWorkerContainerRegister(n){return("serviceWorker"in navigator)?(await navigator.serviceWorker.register(n),!0):!1}export async function serviceWorkerContainerRegisterWithWorkerRegistration(n){if(!("serviceWorker"in navigator))return Promise.reject("Service workers are not supported.");const t=await navigator.serviceWorker.register(n);return createServiceWorkerRegistration(t)}export function serviceWorkerContainerController(){return createServiceWorker(navigator.serviceWorker.controller)}export async function serviceWorkerContainerReady(){const n=await navigator.serviceWorker.ready;return createServiceWorkerRegistration(n)}export async function serviceWorkerContainerGetRegistration(n){const t=await navigator.serviceWorker.getRegistration(n);return t===undefined?undefined:createServiceWorkerRegistration(t)}export async function serviceWorkerContainerGetRegistrations(){const n=await navigator.serviceWorker.getRegistrations();return n.map(n=>DotNet.createJSObjectReference(createServiceWorkerRegistration(n)))}export function serviceWorkerContainerStartMessages(){navigator.serviceWorker.startMessages()}export function serviceWorkerContainerActivateOncontrollerchange(n){navigator.serviceWorker.oncontrollerchange=()=>n.invokeMethodAsync("Trigger")}export function serviceWorkerContainerDeactivateOncontrollerchange(){navigator.serviceWorker.oncontrollerchange=null}export function serviceWorkerContainerActivateOnMessage(n){navigator.serviceWorker.onmessage=()=>n.invokeMethodAsync("Trigger")}export function serviceWorkerContainerDeactivateOnMessage(){navigator.serviceWorker.onmessage=null}export function createServiceWorkerRegistration(n){return new ServiceWorkerRegistrationWrapper(n)}export function sessionStorageLength(){return sessionStorage.length}export function sessionStorageKey(n){return sessionStorage.key(n)}export function sessionStorageGetItem(n){return sessionStorage.getItem(n)}export function sessionStorageSetItem(n,t){sessionStorage.setItem(n,t)}export function sessionStorageRemoveItem(n){sessionStorage.removeItem(n)}export function sessionStorageClear(){sessionStorage.clear()}export class DialogWrapper{#dialog;constructor(n){this.#dialog=n}getOpen(){return this.#dialog.open}setOpen(n){this.#dialog.open=n}getReturnValue(){return this.#dialog.returnValue}setReturnValue(n){this.#dialog.returnValue=n}close(n){this.#dialog.close(n)}show(){this.#dialog.show()}showModal(){this.#dialog.showModal()}activateOncancel(n){this.#dialog.oncancel=()=>n.invokeMethodAsync("Trigger")}deactivateOncancel(){this.#dialog.oncancel=null}activateOnclose(n){this.#dialog.onclose=()=>n.invokeMethodAsync("Trigger")}deactivateOnclose(){this.#dialog.onclose=null}}export class HTMLElementWrapper{#htmlElement;constructor(n){this.#htmlElement=n}getInnerText(){return this.#htmlElement.innerText}setInnerText(n){this.#htmlElement.innerText=n}getOuterText(){return this.#htmlElement.outerText}setOuterText(n){this.#htmlElement.outerText=n}getInlineStyle(){return this.#htmlElement.style.cssText}setInlineStyle(n){this.#htmlElement.style.cssText=n}getOffsetWidth(){return this.#htmlElement.offsetWidth}getOffsetHeight(){return this.#htmlElement.offsetHeight}getOffsetLeft(){return this.#htmlElement.offsetLeft}getOffsetTop(){return this.#htmlElement.offsetTop}getOffsetParent(){return this.#htmlElement.offsetParent}hasFocus(){return this.#htmlElement===document.activeElement}click(){this.#htmlElement.click()}focus(n=false){this.#htmlElement.focus({preventScroll:n})}blur(){this.#htmlElement.blur()}showPopover(){this.#htmlElement.showPopover()}hidePopover(){this.#htmlElement.hidePopover()}togglePopover(n){return this.#htmlElement.togglePopover(n)}getInnerHTML(){return this.#htmlElement.innerHTML}setInnerHTML(n){this.#htmlElement.innerHTML=n}getOuterHTML(){return this.#htmlElement.outerHTML}setOuterHTML(n){this.#htmlElement.outerHTML=n}getAttributes(){const n=this.#htmlElement.attributes;let t={};for(let i=0;i<n.length;i++)Object.assign(t,{[n[i].name]:n[i].value});return t}getChildElementCount(){return this.#htmlElement.childElementCount}getChildren(){return[...this.#htmlElement.children].map(n=>DotNet.createJSObjectReference(createHTMLElement(n)))}getClassName(){return this.#htmlElement.className}setClassName(n){this.#htmlElement.className=n}getClassList(){return[...this.#htmlElement.classList]}getClientWidth(){return this.#htmlElement.clientWidth}getClientHeight(){return this.#htmlElement.clientHeight}getClientLeft(){return this.#htmlElement.clientLeft}getClientTop(){return this.#htmlElement.clientTop}getScrollWidth(){return this.#htmlElement.scrollWidth}getScrollHeight(){return this.#htmlElement.scrollHeight}getScrollLeft(){return this.#htmlElement.scrollLeft}setScrollLeft(n){this.#htmlElement.scrollLeft=n}getScrollTop(){return this.#htmlElement.scrollTop}setScrollTop(n){this.#htmlElement.scrollTop=n}getBoundingClientRect(){return this.#htmlElement.getBoundingClientRect()}getClientRects(){return[...this.#htmlElement.getClientRects()]}hasAttribute(n){return this.#htmlElement.hasAttribute(n)}hasAttributes(){return this.#htmlElement.hasAttributes()}setPointerCapture(n){this.#htmlElement.setPointerCapture(n)}releasePointerCapture(n){this.#htmlElement.releasePointerCapture(n)}hasPointerCapture(n){return this.#htmlElement.hasPointerCapture(n)}scroll(n,t){this.#htmlElement.scroll(n,t)}scrollBy(n,t){this.#htmlElement.scrollBy(n,t)}scrollIntoView(n="start",t="nearest",i="auto"){this.#htmlElement.scrollIntoView({block:n,inline:t,behavior:i})}requestFullscreen(n="auto"){return this.#htmlElement.requestFullscreen({navigationUI:n})}activateOnanimationstart(n){this.#htmlElement.onanimationstart=t=>n.invokeMethodAsync("Trigger",t.animationName,t.elapsedTime,t.pseudoElement)}deactivateOnanimationstart(){this.#htmlElement.onanimationstart=null}activateOnanimationend(n){this.#htmlElement.onanimationend=t=>n.invokeMethodAsync("Trigger",t.animationName,t.elapsedTime,t.pseudoElement)}deactivateOnanimationend(){this.#htmlElement.onanimationend=null}activateOnanimationiteration(n){this.#htmlElement.onanimationiteration=t=>n.invokeMethodAsync("Trigger",t.animationName,t.elapsedTime,t.pseudoElement)}deactivateOnanimationiteration(){this.#htmlElement.onanimationiteration=null}activateOnanimationcancel(n){this.#htmlElement.onanimationcancel=t=>n.invokeMethodAsync("Trigger",t.animationName,t.elapsedTime,t.pseudoElement)}deactivateOnanimationcancel(){this.#htmlElement.onanimationcancel=null}activateOntransitionstart(n){this.#htmlElement.ontransitionstart=t=>n.invokeMethodAsync("Trigger",t.propertyName,t.elapsedTime,t.pseudoElement)}deactivateOntransitionstart(){this.#htmlElement.ontransitionstart=null}activateOntransitionend(n){this.#htmlElement.ontransitionend=t=>n.invokeMethodAsync("Trigger",t.propertyName,t.elapsedTime,t.pseudoElement)}deactivateOntransitionend(){this.#htmlElement.ontransitionend=null}activateOntransitionrun(n){this.#htmlElement.ontransitionrun=t=>n.invokeMethodAsync("Trigger",t.propertyName,t.elapsedTime,t.pseudoElement)}deactivateOntransitionrun(){this.#htmlElement.ontransitionrun=null}activateOntransitioncancel(n){this.#htmlElement.ontransitioncancel=t=>n.invokeMethodAsync("Trigger",t.propertyName,t.elapsedTime,t.pseudoElement)}deactivateOntransitioncancel(){this.#htmlElement.ontransitioncancel=null}}export class ServiceWorkerWrapper{#serviceWorker;constructor(n){this.#serviceWorker=n}scriptURL(){return this.#serviceWorker.scriptURL}state(){return this.#serviceWorker.state}postMessage(n){return this.#serviceWorker.postMessage(n)}activateOnstatechange(n){this.#serviceWorker.onstatechange=t=>n.invokeMethodAsync("Trigger",t.target.state)}deactivateOnstatechange(){this.#serviceWorker.onstatechange=null}activateOnerror(n){this.#serviceWorker.onerror=t=>n.invokeMethodAsync("Trigger",t)}deactivateOnerror(){this.#serviceWorker.onerror=null}}export class ServiceWorkerRegistrationWrapper{#serviceWorkerRegistration;constructor(n){this.#serviceWorkerRegistration=n}active(){return createServiceWorker(this.#serviceWorkerRegistration.active)}installing(){return createServiceWorker(this.#serviceWorkerRegistration.installing)}waiting(){return createServiceWorker(this.#serviceWorkerRegistration.waiting)}scope(){return this.#serviceWorkerRegistration.scope}updateViaCache(){return this.#serviceWorkerRegistration.updateViaCache}unregister(){return this.#serviceWorkerRegistration.unregister()}async update(){const n=await this.#serviceWorkerRegistration.update();return createServiceWorkerRegistration(n)}activateOnupdatefound(n){this.#serviceWorkerRegistration.onupdatefound=()=>n.invokeMethodAsync("Trigger")}deactivateOnupdatefound(){this.#serviceWorkerRegistration.onupdatefound=null}}
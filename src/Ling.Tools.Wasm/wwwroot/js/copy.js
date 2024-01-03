/**
 * Copy element or text to clipboard
 * @param {HTMLElement | string} arg
 * @returns {boolean} true if successful
 */
export function copyToClipboard(arg) {
    if (typeof arg === 'string') {
        navigator.clipboard.writeText(arg);
        return true;
    } else if (arg instanceof HTMLElement) {
        navigator.clipboard.writeText(arg.innerText);
        return true;
    } else {
        console.warn('Invalid parameter passed to copyElementToClipboard');
        return false;
    }
}

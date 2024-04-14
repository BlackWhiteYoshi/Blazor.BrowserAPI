/**
 * @param {string} fileName
 * @param {import("../../blazor").DotNet.DotNetStreamReference} fileContent
 */
export async function downloadAsFile(fileName, fileContent) {
    const arrayBuffer = await fileContent.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);

    const link = document.createElement('a');
    link.href = url;
    link.download = fileName;
    link.click();

    link.remove();
    URL.revokeObjectURL(url);
}

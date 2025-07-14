export class DownloadAPI {
    static async downloadAsFile(fileName: string, fileContent: DotNet.DotNetStreamReference): Promise<void> {
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
}

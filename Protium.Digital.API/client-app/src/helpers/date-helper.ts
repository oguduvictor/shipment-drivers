export const DateHelper = {
    parseToHtmlDate: (dateString: string | Date) => {
        return dateString.toString().replaceAll('/', '-').split('T')[0];
    },

    parseToApiDate: (dateString: string | Date) => {
        return new Date(dateString);
    }
}
export const DateHelper = {
    parseToHtmlInputDate: (dateString: string | Date) => {
        return dateString.toString().replaceAll('/', '-').split('T')[0];
    },

    parseToApiDate: (dateString: string | Date) => {
        return new Date(dateString);
    },

    parseDateToDisplayString: (dateString: string | Date) => {
        return new Date(dateString).toDateString();
    }
}
import { confirmAlert } from 'react-confirm-alert'; // Import
import 'react-confirm-alert/src/react-confirm-alert.css'; // Import css

const ConfirmAlert = (props: { title: string; message: string; onAccepted: () => void; onRejected?: () => {}; }) => (
    confirmAlert({
        title: props.title,
        message: props.message,
        buttons: [
            {
                label: 'Yes',
                onClick: props.onAccepted
            },
            {
                label: 'No',
                onClick: props.onRejected || (() => console.log('No Selected'))
            }
        ]
    })
)

export default ConfirmAlert;
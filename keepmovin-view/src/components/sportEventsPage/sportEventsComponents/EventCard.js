﻿import React, {useState, useEffect} from 'react';
import axios from "axios";
import eventImage from "../../../Images/News-Trailer-Web-4Sep20.png";
import SignalCellularAltIcon from '@mui/icons-material/SignalCellularAlt';
import LocationOnIcon from '@mui/icons-material/LocationOn';
import ArrowRightIcon from "@mui/icons-material/ArrowRight";
import PersonIcon from "@mui/icons-material/Person";



function EventCard(props) {
    const [sportCategory, setSportCategory] = useState([])
    useEffect(() => {
        axios
            .get(`/api/sport/${props.sport}`)
            .then(response => {
                setSportCategory(response.data);
            });
    }, [sportCategory])
    return (
        <div className="event-1">
            <img src={eventImage} alt="" />
            <div className="description">
                <div className="info">
                    <div className="date">
                        {(props.dateStart).slice(0,10)} <span className="info__to">to</span> {(props.dateEnd).slice(0,10)}
                    </div>
                    <div className="title">
                        <h4>{props.eventName}</h4>
                    </div>
                    <div className="category">
                        {sportCategory.name}
                    </div>
                </div>
                <div className="events-statistics">
                    <div className="location">
                        <LocationOnIcon className="location-icon"/>
                        Lacko
                    </div>
                    <div className="events-level">
                        <SignalCellularAltIcon className="level-icon"/>
                        Beginner
                    </div>
                    <div className="events-participants">
                        <PersonIcon className="participants-icon" />
                        0 / {props.maxParticipants}
                    </div>
                </div>
            </div>
            <article className="events__card-nav">
                <div className="events__card-nav-price">{props.price} {props.currency}</div>
                <div className="card-nav__details-join">
                    <div className="events__card-nav-details">Details</div>
                    <div className="events__card-nav-join">Join</div>
                </div>
            </article>
        </div>
    )
}

export default EventCard;
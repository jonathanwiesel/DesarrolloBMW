using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace RapidNote.Controles
{
    public class SemanticUpdatePanel : UpdatePanel
    {
        // We are going to add only 1 property to the UpdatePanel.
        // This property will allow us to change how we want our
        // SemanticUpdatePanel will render.
        private HtmlTextWriterTag renderedElement = HtmlTextWriterTag.Div;

        public HtmlTextWriterTag RenderedElement
        {
            get
            {
                return this.renderedElement;
            }

            set
            {
                this.renderedElement = value;
            }
        }

        // Now we can simply override the "RenderChildren" method and
        // put our own custom logic in here to render the HTML tag
        // that we want to use.
        protected override void RenderChildren(HtmlTextWriter writer)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);

            // This code is here so that we only render the inner contents
            // of the control if it's being called asynchronously.
            if (scriptManager.IsInAsyncPostBack)
            {
                base.RenderChildren(writer);

                return;
            }

            // Of course we need to add our "ID" attribute.
            writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);

            // Here is where we render our own HTML element.
            writer.RenderBeginTag(this.renderedElement);

            // Let the UpdatePanel do it's own magic.
            base.Controls[0].RenderControl(writer);

            // And of course close off the tag.
            writer.RenderEndTag();
        }
    }
}